using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using HexTest.Application.Workflows.Arguments;
using HexTest.Application.Interfaces;
using HexTest.Core;
using HexTest.Core.ProcessAggregate;
using HexTest.SharedKernel;
using HexTest.SharedKernel.Interfaces;
using System.Configuration;


namespace HexTest.Application.Workflows
{   
    public delegate void ProcessCompleteHandler(ProcessOutputArgs processOutputArgs);

    public abstract class Process : BaseProcess
    {
        protected ProcessArgs ProcessArgs;

        public event ProcessCompleteHandler OnProcessComplete;

        public Process(ProcessArgs processArgs)
        {
            this.ProcessArgs = processArgs;
            this.InstanceName = processArgs.ProcessName;
        }

        public async Task<ProcessOutputArgs> Execute(object sender, EventArguments args)
        {
            ProcessOutputArgs processOutputArgs = new ProcessOutputArgs();
            IUnitOfWork unitOfWork = Common.UnitOfWork.GetUnitOfWork();

            await System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    IReadOnlyList<ProcessMaster> processMasters = unitOfWork.ProcessMasterRepository.ListAllAsync(new CancellationToken(false)).Result;

                    ProcessInstance procsessInstance = new ProcessInstance();
                    procsessInstance.Status = ProcessStatus.New;
                    procsessInstance.EntryEvent = this.ProcessArgs.EntryEvent;
                    procsessInstance.Invoker = this.ProcessArgs.Invoker;
                    procsessInstance.ProcessInstanceID = this.InstanceID;

                    if (processMasters != null)
                    {
                        processMasters = processMasters.Where(procMaster => procMaster.Name == this.ProcessArgs.ProcessName).ToList();

                        if (processMasters.Count > 0)
                        {
                            IReadOnlyList<ProcessTaskMapView> procTaskMapViewList = unitOfWork.ProcessTaskMapViewRepository.ListAllAsync(new CancellationToken(false)).Result;

                            if (procTaskMapViewList != null)
                            {
                                procTaskMapViewList = procTaskMapViewList.Where(process => process.ProcessId == processMasters[0].Id).ToList<ProcessTaskMapView>();

                                if (procTaskMapViewList.Count > 0)
                                {
                                    object input = args.Message;
                                    object process_input = args.Message;
                                    string in_event_name = this.ProcessArgs.EntryEvent;
                                    object process_output = "";
                                    int task_count = 1;
                                    //Initially Making Inputs as Outputs
                                    string out_event_name = in_event_name;
                                    object output = input;

                                    //Set ProcessInstance Data
                                    procsessInstance.ProcessID = procTaskMapViewList[0].ProcessId;
                                    procsessInstance.Status = ProcessStatus.InProgress;
                                    procsessInstance.InputData = Newtonsoft.Json.JsonConvert.SerializeObject(process_input);

                                    //Process All Tasks in Order
                                    foreach (ProcessTaskMapView procTaskMapView in procTaskMapViewList)
                                    {
                                        //Comment by Varaprasad
                                        //TODO :: Task Execution Sequence should be Recheck for the Flow

                                        #region Task Execution Logic
                                        if (procTaskMapView.EventName == out_event_name)
                                        {
                                            //Make out as in
                                            in_event_name = out_event_name;
                                            input = output;

                                            //Create Event Instance Log
                                            EventInstance eventInstance = new EventInstance()
                                            {
                                                EventId = procTaskMapView.EventId,
                                                EventName = in_event_name,
                                                ProcessID = procsessInstance.ProcessID,
                                                ProcessInstanceId = procsessInstance.ProcessInstanceID
                                            };

                                            //Get the TaskName
                                            //string task_name = procTaskMapView.TaskName;
                                            //Get the Task Class Name
                                            string TaskClassName = procTaskMapView.TaskName;
                                            Type t = Type.GetType(TaskClassName);

                                            dynamic objectRet;
                                            BaseTask? TaskClassInstance;

                                            if (task_count >= 1)
                                            {
                                                //Create TaskInstance Log Here
                                                TaskInstance taskInstance = new TaskInstance()
                                                {
                                                    TaskID = procTaskMapView.TaskId,
                                                    ProcessID = procsessInstance.ProcessID,
                                                    ProcessInstanceId = procsessInstance.ProcessInstanceID,
                                                    InputEvent = in_event_name,
                                                    InputData = Newtonsoft.Json.JsonConvert.SerializeObject(input),
                                                    OutputData = "",
                                                    Status = Core.ProcessAggregate.TaskStatus.InProgress
                                                };

                                                try
                                                {
                                                    //Executing Task Here
                                                    TaskClassInstance = (BaseTask)Activator.CreateInstance(t);
                                                    object[] invokeArgs = { input };
                                                    MethodInfo toInvoke = t.GetMethod("Execute");

                                                    //Set Task InstanceID
                                                    taskInstance.TaskInstanceId = TaskClassInstance.InstanceID;

                                                    //Set Event Task Data
                                                    eventInstance.TaskInstanceId = taskInstance.TaskInstanceId;
                                                    eventInstance.TaskID = taskInstance.TaskID;

                                                    //Execute Task
                                                    objectRet = toInvoke.Invoke(TaskClassInstance, invokeArgs);

                                                    //Read the Outputs
                                                    if (objectRet != null)
                                                    {
                                                        output = objectRet.Item1;
                                                        out_event_name = objectRet.Item2;
                                                    }
                                                    else
                                                    {
                                                        output = null;
                                                        out_event_name = "";
                                                    }

                                                    //Check required if output frm task is Null -- Do What Abort the Process or to Continue

                                                    taskInstance.OutputEvent = out_event_name;
                                                    taskInstance.OutputData = Newtonsoft.Json.JsonConvert.SerializeObject(output);
                                                    taskInstance.EndDateTime = DateTime.Now;
                                                    taskInstance.Status = Core.ProcessAggregate.TaskStatus.Completed;
                                                    taskInstance.Exception = "";

                                                }
                                                catch (Exception ex)
                                                {
                                                    taskInstance.OutputEvent = "";
                                                    taskInstance.OutputData = "";
                                                    taskInstance.EndDateTime = DateTime.Now;
                                                    taskInstance.Status = Core.ProcessAggregate.TaskStatus.Aborted;
                                                    taskInstance.Exception = ex.Message + "\r\n" + ex.StackTrace;

                                                    //Aborte Process Execution and Save Logs  ??????

                                                }

                                                process_output = output;
                                                unitOfWork.TaskInstanceRepository.AddAsync(taskInstance, new CancellationToken(false)).Wait();

                                            }
                                            else
                                            {
                                                //No Tasks Maps Found Process Execution Completed
                                                process_output = "";
                                                procsessInstance.EndDateTime = DateTime.Now;
                                                procsessInstance.Status = ProcessStatus.Completed;
                                                unitOfWork.ProcessInstanceRepository.AddAsync(procsessInstance, new CancellationToken(false)).Wait();
                                            }

                                            //Save EventInstance Logs
                                            unitOfWork.EventInstanceRepository.AddAsync(eventInstance, new CancellationToken(false)).Wait();

                                        }
                                        #endregion

                                        task_count += 1;

                                    } //End of foreach TaskViewMap

                                    procsessInstance.OutputData = Newtonsoft.Json.JsonConvert.SerializeObject(process_output);
                                    procsessInstance.EndDateTime = DateTime.Now;
                                    procsessInstance.Status = ProcessStatus.Completed;
                                    unitOfWork.ProcessInstanceRepository.AddAsync(procsessInstance, new CancellationToken(false)).Wait();

                                    processOutputArgs.ExitCode = 0;
                                    processOutputArgs.Exception = null;
                                    processOutputArgs.ProcessOutput = procsessInstance.OutputData;

                                }
                                else
                                {
                                    processOutputArgs.ExitCode = -1;
                                    processOutputArgs.Exception = new Exception("Process Tasks Maps Not Found");
                                    processOutputArgs.ProcessOutput = "";

                                    procsessInstance.EndDateTime = DateTime.Now;
                                    procsessInstance.Status = ProcessStatus.Completed;
                                    unitOfWork.ProcessInstanceRepository.AddAsync(procsessInstance, new CancellationToken(false)).Wait();
                                }

                            }
                            else
                            {
                                processOutputArgs.ExitCode = -1;
                                processOutputArgs.Exception = new Exception("Process Tasks Maps Not Found");
                                processOutputArgs.ProcessOutput = "";

                                procsessInstance.EndDateTime = DateTime.Now;
                                procsessInstance.Status = ProcessStatus.Completed;
                                unitOfWork.ProcessInstanceRepository.AddAsync(procsessInstance, new CancellationToken(false)).Wait();

                            } //End of ProcTaskMapView

                        }
                        else
                        {
                            processOutputArgs.ExitCode = -1;
                            processOutputArgs.Exception = new Exception("Process not Found");
                            processOutputArgs.ProcessOutput = "";

                            procsessInstance.EndDateTime = DateTime.Now;
                            procsessInstance.Status = ProcessStatus.Aborted;
                            procsessInstance.Exception = "Process not Found";
                            unitOfWork.ProcessInstanceRepository.AddAsync(procsessInstance, new CancellationToken(false)).Wait();
                        }//End of ProcessMaster Inner

                    }
                    else
                    {
                        processOutputArgs.ExitCode = -1;
                        processOutputArgs.Exception = new Exception("Process not Found");
                        processOutputArgs.ProcessOutput = "";

                        procsessInstance.EndDateTime = DateTime.Now;
                        procsessInstance.Status = ProcessStatus.Aborted;
                        procsessInstance.Exception = "Process not Found";
                        unitOfWork.ProcessInstanceRepository.AddAsync(procsessInstance, new CancellationToken(false)).Wait();
                    }//End of ProcessMaster Outer

                }
                catch (Exception ex)
                {
                    processOutputArgs.ExitCode = -1;
                    processOutputArgs.Exception = ex;
                    processOutputArgs.ProcessOutput = "";
                }

                //Fire OnProcessComplete Event to Listner
                if (OnProcessComplete != null) OnProcessComplete(processOutputArgs);

            });

            return processOutputArgs;

        }//End of Method Execute
    
    }// End of Class Process
}
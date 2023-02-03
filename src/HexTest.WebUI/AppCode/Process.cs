using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HexTest.WebUI.DataAccessLayer;
using HexTest.WebUI.Utilities;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using HexTest.WebUI.Workflows.Arguments;

namespace HexTest.WebUI.Workflows
{
	public delegate void ProcessCompleteHandler(ProcessOutputArgs processOutputArgs);
	public class Process
	{
		private string ConnectionString = "";

		private ProcessArgs ProcessArgs;

		public event ProcessCompleteHandler OnProcessComplete;

		public Process(ProcessArgs processArgs)
		{
			ConnectionString = @"Server=" + Common.ProjectProperties.get("HostName") + "; Port = " + Common.ProjectProperties.get("Port") + "; Uid = " + Common.ProjectProperties.get("UserID") + "; Pwd = " + Common.ProjectProperties.get("Password") + "; Database = " + Common.ProjectProperties.get("DatabaseName") + "; ";

			this.ProcessArgs = processArgs;
		}

		public void Subscribe(Publisher pub)
		{
			//pub.myEvent += Execute;
		}

		public void UnSubscribe(Publisher pub)
		{
			//pub.myEvent -= Execute;
		}

		public async Task<ProcessOutputArgs> Execute(object sender, EventArguments args)
		{
			ProcessOutputArgs processOutputArgs = new ProcessOutputArgs();
			await Task.Run(() =>
			{
				//try
				//{	
				//	Database mydb = new MySqlDatabase(ConnectionString);
				//	DataTable dt = mydb.ExecuteDataSet("SELECT * from process_task_map_view where process_name = '" + this.ProcessArgs.ProcessName + "' order by id").Tables[0];
				//	object input = args.Message;
				//	object process_input = args.Message;
				//	string event_name = this.ProcessArgs.Invoker;
				//	int task_count = 1;
				//	mydb.Execute("Insert into process_instance(process_id, start_event_instance_id) values('" + dt.Rows[0]["process_id"].ToString() + "', '" + dt.Rows[0]["event_id"].ToString() + "')");

				//	foreach (DataRow row in dt.Rows)
				//	{
				//		if (row["event_name"].ToString() == event_name)
				//		{
				//			int process_instance_id = Int32.Parse(mydb.ExecuteScalar("select max(id) from process_instance where process_id = '" + dt.Rows[0]["process_id"].ToString() + "'").ToString());
				//			mydb.Execute("Insert into event_instance(process_instance_id, event_id) values(" + process_instance_id + ", '" + row["event_id"].ToString() + "')");
				//			string task_name = row["task_name"].ToString();
				//			string file_name = "Sonance." + Common.ProjectProperties.get("ProjectCode") + "." + task_name;
				//			Type t = Type.GetType(file_name);
				//			dynamic objectRet;
				//			if (task_count == 1 || input == process_input)
				//			{
				//				object TaskInstance = Activator.CreateInstance(t);
				//				object[] invokeArgs = { input };
				//				MethodInfo toInvoke = t.GetMethod("execute");
				//				objectRet = toInvoke.Invoke(TaskInstance, invokeArgs);
				//			}
				//			else
				//			{
				//				object TaskInstance = Activator.CreateInstance(t);
				//				object[] invokeArgs = { input, process_input };
				//				MethodInfo toInvoke = t.GetMethod("execute");
				//				objectRet = toInvoke.Invoke(TaskInstance, invokeArgs);
				//			}
				//			dynamic input_data_instance = input;
				//			int input_instance_id = input_data_instance.GetType().GetProperty("PKID" + row["input_data"].ToString()).GetValue(input_data_instance, null);
				//			int check_output = Int32.Parse(mydb.ExecuteScalar("select count(*) from process_prod_modules where db_mname = '" + objectRet.Item1.GetType().Name + "'").ToString());
				//			int out_instance_id = 0;
				//			if (check_output > 0)
				//			{
				//				dynamic out_data_instance = objectRet.Item1;
				//				out_instance_id = out_data_instance.GetType().GetProperty("PKID" + objectRet.Item1.GetType().Name).GetValue(out_data_instance, null);
				//			}
				//			input = objectRet.Item1;
				//			event_name = objectRet.Item2;
				//			int event_instance_id = Int32.Parse(mydb.ExecuteScalar("select max(id) from event_instance where event_id = '" + row["event_id"].ToString() + "'").ToString());
				//			mydb.Execute("Insert into task_instance(task_id, process_instance_id, event_instance_id, input_entity_instance_id, output_entity_instance_id) values('" + dt.Rows[0]["task_id"] + "', " + process_instance_id + ", " + event_instance_id + ", " + input_instance_id + ", " + out_instance_id + ")");
				//		}
				//		task_count += 1;
				//	}

				//	processOutputArgs.ExitCode = 0;
				//	processOutputArgs.Exception = null;
				//	processOutputArgs.ProcessOutput = Newtonsoft.Json.JsonConvert.SerializeObject(input);

				//}
				//catch (Exception ex)
				//{
				//	processOutputArgs.ExitCode = -1;
				//	processOutputArgs.Exception = ex;
				//	processOutputArgs.ProcessOutput = "";
				//}

				//if (OnProcessComplete != null) OnProcessComplete(processOutputArgs);
				
			});

			return processOutputArgs;

		}//End of Method Execute
	}
}
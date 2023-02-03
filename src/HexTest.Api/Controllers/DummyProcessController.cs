using Microsoft.AspNetCore.Mvc;
using HexTest.Application.Workflows.Arguments;
using HexTest.Application.Workflows;
using SerilogTimings;
using System.Reflection;
using HexTest.SharedKernel.Interfaces;

namespace HexTest.Api.Controllers
{
    public class DummyProcessController : Controller
    {   
        private readonly ILogger<DummyProcessController> logger;

        public DummyProcessController(ILogger<DummyProcessController> logger)
        {
            this.logger = logger;            
        }

        public IActionResult Index()
        {
            //Invoker Values can be WebForm, API, Others
            //This is primarly to know the Source of Invokation
            //Default is Web if not defined
            DummyProcess dp = new DummyProcess(new ProcessArgs() { Invoker = "Web", EntryEvent= "Entry_Event_Name", ProcessName = "Process_Name" });
            dp.OnProcessComplete += new ProcessCompleteHandler(Dp_OnProcessComplete);
            Task<ProcessOutputArgs> processOutputArgs = dp.Execute(new object(), new EventArguments("Object_As_Input_Argument"));

            processOutputArgs.Wait();

            logger.LogInformation("Exit Code : " + processOutputArgs.Result.ExitCode);
            logger.LogInformation("Process Output : " + processOutputArgs.Result.ProcessOutput);
            logger.LogError(processOutputArgs.Result.Exception, "Exception Details");

            return View();
        }

        private void Dp_OnProcessComplete(ProcessOutputArgs processOutputArgs)
        {   
            logger.LogInformation("Exit Code : " + processOutputArgs.ExitCode);
            logger.LogInformation("Process Output : " + processOutputArgs.ProcessOutput);
            logger.LogError(processOutputArgs.Exception, "Exception Details");
        }
    }
}

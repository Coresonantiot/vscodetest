using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HexTest.WebUI.Models;
using HexTest.WebUI.DataAccessLayer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using FluentValidation.Results;
using Newtonsoft.Json;
//Namespaces


namespace HexTest.WebUI.Pages
{
    //Authorization
    public class jobModel : PageModel
    {
        private readonly ILogger<jobModel> _logger;

        public jobModel(ILogger<jobModel> logger)
        {
            _logger = logger;
        }

        public IList<job> jobList { get; set; } = default!;

        public void OnGet()
		{
			ApiHandler ApiHandler = new ApiHandler();
			jobList = ApiHandler.Get<job>();
		}


        public PartialViewResult OnGetAddOrEdit(int id = 0)
		{
			ApiHandler ApiHandler = new ApiHandler();
			job job;
			if (id == 0)
				job = new job();
			else
				job = ApiHandler.Get<job>(id).FirstOrDefault();
			return new PartialViewResult
			{
				ViewName = "jobAddOrEdit",
				ViewData = new ViewDataDictionary<job>(ViewData, job)
			};
		}


        public JsonResult OnPostAddOrEdit(int id, job job)
		{
			jobValidator validatorjob = new jobValidator();
			ValidationResult result = validatorjob.Validate(job);
			if (result.IsValid)
			{
				ApiHandler ApiHandler = new ApiHandler();
				if (id == 0)
					ApiHandler.Save<job>(job);
				else
					ApiHandler.Update<job>(job);
				return new JsonResult(new { isValid = true });
			}
			else
			{
				IList<ValidationFailure> failures = result.Errors;
				return new JsonResult(new { isValid = false, errors = failures });
			}
		}


        public IActionResult OnPostDelete(int id)
		{
			ApiHandler ApiHandler = new ApiHandler();
			ApiHandler.Delete<job>(id);
			return RedirectToAction(actionName: "Get");
		}


        
        
    }
}
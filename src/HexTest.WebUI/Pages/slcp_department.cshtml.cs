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
    public class slcp_departmentModel : PageModel
    {
        private readonly ILogger<slcp_departmentModel> _logger;

        public slcp_departmentModel(ILogger<slcp_departmentModel> logger)
        {
            _logger = logger;
        }

        public IList<slcp_department> slcp_departmentList { get; set; } = default!;

        public void OnGet()
		{
			ApiHandler ApiHandler = new ApiHandler();
			slcp_departmentList = ApiHandler.Get<slcp_department>();
		}


        public PartialViewResult OnGetAddOrEdit(int id = 0)
		{
			ApiHandler ApiHandler = new ApiHandler();
			slcp_department slcp_department;
			if (id == 0)
				slcp_department = new slcp_department();
			else
				slcp_department = ApiHandler.Get<slcp_department>(id).FirstOrDefault();
			return new PartialViewResult
			{
				ViewName = "slcp_departmentAddOrEdit",
				ViewData = new ViewDataDictionary<slcp_department>(ViewData, slcp_department)
			};
		}


        public JsonResult OnPostAddOrEdit(int id, slcp_department slcp_department)
		{
			slcp_departmentValidator validatorslcp_department = new slcp_departmentValidator();
			ValidationResult result = validatorslcp_department.Validate(slcp_department);
			if (result.IsValid)
			{
				ApiHandler ApiHandler = new ApiHandler();
				if (id == 0)
					ApiHandler.Save<slcp_department>(slcp_department);
				else
					ApiHandler.Update<slcp_department>(slcp_department);
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
			ApiHandler.Delete<slcp_department>(id);
			return RedirectToAction(actionName: "Get");
		}


        
        
    }
}
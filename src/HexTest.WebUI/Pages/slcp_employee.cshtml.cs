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
    public class slcp_employeeModel : PageModel
    {
        private readonly ILogger<slcp_employeeModel> _logger;

        public slcp_employeeModel(ILogger<slcp_employeeModel> logger)
        {
            _logger = logger;
        }

        public IList<slcp_employee> slcp_employeeList { get; set; } = default!;

        public void OnGet()
		{
			ApiHandler ApiHandler = new ApiHandler();
			slcp_employeeList = ApiHandler.Get<slcp_employee>();
		}


        public PartialViewResult OnGetAddOrEdit(int id = 0)
		{
			ApiHandler ApiHandler = new ApiHandler();
			slcp_employee slcp_employee;
			if (id == 0)
				slcp_employee = new slcp_employee();
			else
				slcp_employee = ApiHandler.Get<slcp_employee>(id).FirstOrDefault();
			return new PartialViewResult
			{
				ViewName = "slcp_employeeAddOrEdit",
				ViewData = new ViewDataDictionary<slcp_employee>(ViewData, slcp_employee)
			};
		}


        public JsonResult OnPostAddOrEdit(int id, slcp_employee slcp_employee)
		{
			slcp_employeeValidator validatorslcp_employee = new slcp_employeeValidator();
			ValidationResult result = validatorslcp_employee.Validate(slcp_employee);
			if (result.IsValid)
			{
				ApiHandler ApiHandler = new ApiHandler();
				if (id == 0)
					ApiHandler.Save<slcp_employee>(slcp_employee);
				else
					ApiHandler.Update<slcp_employee>(slcp_employee);
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
			ApiHandler.Delete<slcp_employee>(id);
			return RedirectToAction(actionName: "Get");
		}


        
        
    }
}
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
    public class slcp_carModel : PageModel
    {
        private readonly ILogger<slcp_carModel> _logger;

        public slcp_carModel(ILogger<slcp_carModel> logger)
        {
            _logger = logger;
        }

        public IList<slcp_car> slcp_carList { get; set; } = default!;

        public void OnGet()
		{
			ApiHandler ApiHandler = new ApiHandler();
			slcp_carList = ApiHandler.Get<slcp_car>();
		}


        public PartialViewResult OnGetAddOrEdit(int id = 0)
		{
			ApiHandler ApiHandler = new ApiHandler();
			slcp_car slcp_car;
			if (id == 0)
				slcp_car = new slcp_car();
			else
				slcp_car = ApiHandler.Get<slcp_car>(id,"slcp_engine,slcp_wheel").FirstOrDefault();
			return new PartialViewResult
			{
				ViewName = "slcp_carAddOrEdit",
				ViewData = new ViewDataDictionary<slcp_car>(ViewData, slcp_car)
			};
		}


        public JsonResult OnPostAddOrEdit(int id, slcp_car slcp_car)
		{
			slcp_carValidator validatorslcp_car = new slcp_carValidator();
			ValidationResult result = validatorslcp_car.Validate(slcp_car);
			if (result.IsValid)
			{
				ApiHandler ApiHandler = new ApiHandler();
				if (id == 0)
					ApiHandler.Save<slcp_car>(slcp_car);
				else
					ApiHandler.Update<slcp_car>(slcp_car);
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
			ApiHandler.Delete<slcp_car>(id);
			return RedirectToAction(actionName: "Get");
		}


        
        
    }
}
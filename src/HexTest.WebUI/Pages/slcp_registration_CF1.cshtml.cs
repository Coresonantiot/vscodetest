using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HexTest.WebUI.Models;
using HexTest.WebUI.DataAccessLayer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using FluentValidation.Results;

namespace HexTest.WebUI.Pages
{
    public class slcp_registration_CF1Model : PageModel
    {
        private readonly ILogger<slcp_registration_CF1Model> _logger;

        public slcp_registration_CF1Model(ILogger<slcp_registration_CF1Model> logger)
        {
            _logger = logger;
        }


        public JsonResult OnPostSave(slcp_registration_CF1 slcp_registration_CF1)
		{
			ApiHandler ApiHandler = new ApiHandler();
			ApiHandler.Save<slcp_registration_CF1>(slcp_registration_CF1);
			return new JsonResult(new { isValid = true });
		}

        
    }
}
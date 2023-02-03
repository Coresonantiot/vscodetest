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
    public class slcp_employee_department_mapModel : PageModel
    {
        private readonly ILogger<slcp_employee_department_mapModel> _logger;

        public slcp_employee_department_mapModel(ILogger<slcp_employee_department_mapModel> logger)
        {
            _logger = logger;
        }

        public IList<slcp_employee_department_map> slcp_employee_department_mapList { get; set; } = default!;

        public void OnGet()
		{
			ApiHandler ApiHandler = new ApiHandler();
			slcp_employee_department_mapList = ApiHandler.Get<slcp_employee_department_map>();
			foreach (var slcp_employee_department_map in slcp_employee_department_mapList)
			{
				slcp_employee_department_map.slcp_employee = ApiHandler.Get<slcp_employee>(slcp_employee_department_map.slcp_employeeId)[0];
				slcp_employee_department_map.slcp_department = ApiHandler.Get<slcp_department>(slcp_employee_department_map.slcp_departmentId)[0];
			}
		}


        public PartialViewResult OnGetAddOrEdit(int id = 0)
		{
			ApiHandler ApiHandler = new ApiHandler();
			slcp_employee_department_map slcp_employee_department_map;
			if (id == 0)
				slcp_employee_department_map = new slcp_employee_department_map();
			else
			{
				slcp_employee_department_map = ApiHandler.Get<slcp_employee_department_map>(id).FirstOrDefault();
				slcp_employee_department_map.slcp_employee = ApiHandler.Get<slcp_employee>(slcp_employee_department_map.slcp_employeeId)[0];
				slcp_employee_department_map.slcp_department = ApiHandler.Get<slcp_department>(slcp_employee_department_map.slcp_departmentId)[0];
			}
			return new PartialViewResult
			{
				ViewName = "slcp_employee_department_mapAddOrEdit",
				ViewData = new ViewDataDictionary<slcp_employee_department_map>(ViewData, slcp_employee_department_map)
			};
		}


        public JsonResult OnPostAddOrEdit(int id, slcp_employee_department_map slcp_employee_department_map)
		{
			ApiHandler ApiHandler = new ApiHandler();
			if (id == 0)
				ApiHandler.Save<slcp_employee_department_map>(slcp_employee_department_map);
			else
				ApiHandler.Update<slcp_employee_department_map>(slcp_employee_department_map);
			return new JsonResult(new { isValid = true });
		}


        public IActionResult OnPostDelete(int id)
		{
			ApiHandler ApiHandler = new ApiHandler();
			ApiHandler.Delete<slcp_employee_department_map>(id);
			return RedirectToAction(actionName: "Get");
		}


        public IActionResult OnGetAttributeData(string inputText, string tablename, string fieldname)
		{
			string json;
			ApiHandler ApiHandler = new ApiHandler();
			if(tablename == "slcp_employee")
			{
				List<slcp_employee> list = ApiHandler.GetAll<slcp_employee>().Where(x => x.GetType().GetProperty(fieldname).GetValue(x, null).ToString().Contains(inputText)).ToList();
				json = JsonConvert.SerializeObject(list);
			}
			else
			{
				List<slcp_department> list = ApiHandler.GetAll<slcp_department>().Where(x => x.GetType().GetProperty(fieldname).GetValue(x, null).ToString().Contains(inputText)).ToList();
				json = JsonConvert.SerializeObject(list);
			}
			return Content(json);
		}

        
    }
}
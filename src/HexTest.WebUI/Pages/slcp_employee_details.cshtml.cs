using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HexTest.WebUI.Models;
using HexTest.WebUI.DataAccessLayer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using FluentValidation.Results;
using System.Data;

namespace HexTest.WebUI.Pages
{
    public class slcp_employee_detailsModel : PageModel
    {
        private readonly ILogger<slcp_employee_detailsModel> _logger;

        public slcp_employee_detailsModel(ILogger<slcp_employee_detailsModel> logger)
        {
            _logger = logger;
        }

        public DataTable dt = new DataTable();
        
        public void OnGet()
		{

            slcp_employee_detailsData();
        } 
        
        public void slcp_employee_detailsData
			( )
		{


			string MainQuery = @"SELECT   cast(slcp_employees.slcp_name as char) as `Employee Name`,  cast(slcp_employees.slcp_emp_code as char) as `Employee Code`,  cast(slcp_departments.slcp_dept_name as char) as `Department Name` from slcp_employee_department_maps inner join  slcp_employees  on  slcp_employee_department_maps.slcp_employeeId = slcp_employees.Id  inner join  slcp_departments  on  slcp_employee_department_maps.slcp_departmentId = slcp_departments.Id ";

			ApiHandler ApiHandler = new ApiHandler();
			dt = ApiHandler.GetQueryResult("Reports/slcp_employee_details",MainQuery);

		}
        
    }
}
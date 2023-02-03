using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using HexTest.Infrastructure.Data;

namespace HexTest.Api.Controllers
{
    public class ReportsController : Controller
    {

        private readonly AppDbContext _context;
        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("api/Reports/rpt_slcp_employee_details")]
		public async Task<ActionResult> slcp_employee_details(string query)
		{
			_context.Database.OpenConnection();
			var command = _context.Database.GetDbConnection().CreateCommand();
			command.CommandText = query;
			IDataReader dataReader = command.ExecuteReader();
			DataTable result = new DataTable();
			result.Load(dataReader);
			return Ok(result);
		}

		//<#QueryControllerMethod#>
    }
}

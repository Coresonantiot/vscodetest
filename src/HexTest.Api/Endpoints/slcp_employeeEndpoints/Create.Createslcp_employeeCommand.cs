using System.ComponentModel.DataAnnotations;
using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employees;

public class Createslcp_employeeCommand
{
  public int Id { get; set; }
  	public string? slcp_name { get; set; }

	public string? slcp_Joinmonth { get; set; }

	[Required]
	public string slcp_emp_code { get; set; }

	public string? slcp_address { get; set; }


  //<#SubEntityAttribs#>
}

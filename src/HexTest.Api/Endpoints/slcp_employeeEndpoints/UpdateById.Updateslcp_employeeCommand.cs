using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employees;

public class Updateslcp_employeeCommandById
{
  [Required]
  [FromRoute]
  public int Id { get; set; }

  [FromBody]
  public UpdateDetails Details { get; set; }

  public class UpdateDetails
  {
    	public string? slcp_name { get; set; }

	public string? slcp_Joinmonth { get; set; }

	[Required]
	public string slcp_emp_code { get; set; }

	public string? slcp_address { get; set; }


  }

}

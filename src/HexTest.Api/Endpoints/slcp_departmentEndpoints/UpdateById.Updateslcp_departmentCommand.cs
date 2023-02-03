using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using HexTest.Core.slcp_departmentAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_departments;

public class Updateslcp_departmentCommandById
{
  [Required]
  [FromRoute]
  public int Id { get; set; }

  [FromBody]
  public UpdateDetails Details { get; set; }

  public class UpdateDetails
  {
    	[Required]
	public string slcp_dept_name { get; set; }

	[Required]
	public string slcp_dept_code { get; set; }


  }

}

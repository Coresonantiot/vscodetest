using System.ComponentModel.DataAnnotations;
using HexTest.Core.slcp_departmentAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_departments;

public class Updateslcp_departmentCommand
{ 
  public int Id { get; set; }
  	[Required]
	public string slcp_dept_name { get; set; }

	[Required]
	public string slcp_dept_code { get; set; }


  //<#SubEntityAttribs#>
}

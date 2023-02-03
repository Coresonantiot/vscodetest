using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

public class Updateslcp_carCommandById
{
  [Required]
  [FromRoute]
  public int Id { get; set; }

  [FromBody]
  public UpdateDetails Details { get; set; }

  public class UpdateDetails
  {
    	[Required]
	public string slcp_colour { get; set; }

	public string? slcp_isshipped { get; set; }


  }

}

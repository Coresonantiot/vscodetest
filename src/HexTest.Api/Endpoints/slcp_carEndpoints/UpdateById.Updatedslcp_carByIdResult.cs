using System.ComponentModel.DataAnnotations;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

public class Updatedslcp_carByIdResult
{
  public string Id { get; set; }
  	[Required]
	public string slcp_colour { get; set; }

	public string? slcp_isshipped { get; set; }


}

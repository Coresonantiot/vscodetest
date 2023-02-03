using System.ComponentModel.DataAnnotations;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

public class Updateslcp_carCommand
{ 
  public int Id { get; set; }
  	[Required]
	public string slcp_colour { get; set; }

	public string? slcp_isshipped { get; set; }


  public slcp_engine slcp_engine { get; set; }
public int slcp_engineId { get; set; }
public ICollection<slcp_wheel> slcp_wheel { get; set; }
//<#SubEntityAttribs#>
}

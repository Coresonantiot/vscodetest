using System.ComponentModel.DataAnnotations;
using HexTest.Core.slcp_registration_CF1Aggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_registration_CF1s;

public class slcp_registration_CF1GetByQueryResult
{
  public int Id { get; set; }
  public slcp_registration_CF1_slcp_employee slcp_registration_CF1_slcp_employee{ get; set; }

public slcp_registration_CF1_slcp_department slcp_registration_CF1_slcp_department{ get; set; }


  //<#SubEntityAttribs#>
}
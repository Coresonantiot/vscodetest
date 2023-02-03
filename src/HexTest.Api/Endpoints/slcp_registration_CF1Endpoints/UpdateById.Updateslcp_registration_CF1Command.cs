using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using HexTest.Core.slcp_registration_CF1Aggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_registration_CF1s;

public class Updateslcp_registration_CF1CommandById
{
  [Required]
  [FromRoute]
  public int Id { get; set; }

  [FromBody]
  public UpdateDetails Details { get; set; }

  public class UpdateDetails
  {
    public slcp_registration_CF1_slcp_employee slcp_registration_CF1_slcp_employee{ get; set; }

public slcp_registration_CF1_slcp_department slcp_registration_CF1_slcp_department{ get; set; }


  }

}

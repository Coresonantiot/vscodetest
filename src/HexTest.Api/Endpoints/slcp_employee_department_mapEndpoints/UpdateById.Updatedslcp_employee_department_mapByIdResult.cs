using System.ComponentModel.DataAnnotations;
using HexTest.Core.slcp_employee_department_mapAggregate;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Core.slcp_departmentAggregate;
//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employee_department_maps;

public class Updatedslcp_employee_department_mapByIdResult
{
  public string Id { get; set; }
  public int slcp_employeeId { get; set; }

public int slcp_departmentId { get; set; }


}

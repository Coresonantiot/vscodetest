using System.ComponentModel.DataAnnotations;
using HexTest.Core.slcp_employee_department_mapAggregate;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Core.slcp_departmentAggregate;
//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employee_department_maps;

public class slcp_employee_department_mapGetByQueryResult
{
  public int Id { get; set; }
  public int slcp_employeeId { get; set; }

public int slcp_departmentId { get; set; }


  //<#SubEntityAttribs#>
}
using HexTest.Core.slcp_employee_department_mapAggregate;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Core.slcp_departmentAggregate;
//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employee_department_maps;

public class slcp_employee_department_mapListRequest
{
  public int Page { get; set; }
  public int PerPage { get; set; }
}

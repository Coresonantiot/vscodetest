using HexTest.Core.slcp_employee_department_mapAggregate;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Core.slcp_departmentAggregate;
//<#AddNamespaces#>


namespace HexTest.Api.Endpoints.slcp_employee_department_maps;

public class slcp_employee_department_mapGetByQueryRequest
{
  public int Id { get; set; }
  public string ?includeProperties { get; set; }
}

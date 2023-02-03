using HexTest.Core.slcp_employee_department_mapAggregate;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Core.slcp_departmentAggregate;
//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employee_department_maps;

public class Createslcp_employee_department_mapResult : Createslcp_employee_department_mapCommand
{
   public int Id { get; set; }
}

using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>


namespace HexTest.Api.Endpoints.slcp_employees;

public class slcp_employeeGetByQueryRequest
{
  public int Id { get; set; }
  public string ?includeProperties { get; set; }
}

using HexTest.Core.slcp_departmentAggregate;
		//<#AddNamespaces#>


namespace HexTest.Api.Endpoints.slcp_departments;

public class slcp_departmentGetByQueryRequest
{
  public int Id { get; set; }
  public string ?includeProperties { get; set; }
}

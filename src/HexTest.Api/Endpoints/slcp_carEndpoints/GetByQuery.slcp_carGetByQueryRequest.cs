using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>


namespace HexTest.Api.Endpoints.slcp_cars;

public class slcp_carGetByQueryRequest
{
  public int Id { get; set; }
  public string ?includeProperties { get; set; }
}

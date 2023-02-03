using HexTest.Core.jobAggregate;
		//<#AddNamespaces#>


namespace HexTest.Api.Endpoints.jobs;

public class jobGetByQueryRequest
{
  public int Id { get; set; }
  public string ?includeProperties { get; set; }
}

using HexTest.Core.jobAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.jobs;

public class jobListRequest
{
  public int Page { get; set; }
  public int PerPage { get; set; }
}

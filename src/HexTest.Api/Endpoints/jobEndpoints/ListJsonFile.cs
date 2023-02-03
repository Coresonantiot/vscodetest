using System.Text.Json;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.jobAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.jobs;

[Tags("jobs")]
public class ListJsonFile : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
  private readonly IAsyncRepository<job> repository;

  public ListJsonFile(IAsyncRepository<job> repository)
  {
    this.repository = repository;
  }

  /// <summary>
  /// List all jobs as a JSON file
  /// </summary>
  [HttpGet("api/[namespace]/Json")]
  public override async Task<ActionResult> HandleAsync(
      CancellationToken cancellationToken = default)
  {
    var result = (await repository.ListAllAsync(cancellationToken)).ToList();

    var streamData = JsonSerializer.SerializeToUtf8Bytes(result);
    return File(streamData, "text/json", "job.json");
  }
}

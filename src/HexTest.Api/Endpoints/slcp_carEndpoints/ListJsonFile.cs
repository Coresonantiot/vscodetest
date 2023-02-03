using System.Text.Json;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

[Tags("slcp_cars")]
public class ListJsonFile : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_car> repository;

  public ListJsonFile(IAsyncRepository<slcp_car> repository)
  {
    this.repository = repository;
  }

  /// <summary>
  /// List all slcp_cars as a JSON file
  /// </summary>
  [HttpGet("api/[namespace]/Json")]
  public override async Task<ActionResult> HandleAsync(
      CancellationToken cancellationToken = default)
  {
    var result = (await repository.ListAllAsync(cancellationToken)).ToList();

    var streamData = JsonSerializer.SerializeToUtf8Bytes(result);
    return File(streamData, "text/json", "slcp_car.json");
  }
}

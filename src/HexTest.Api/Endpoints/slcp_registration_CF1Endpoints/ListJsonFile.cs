using System.Text.Json;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_registration_CF1Aggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_registration_CF1s;

[Tags("slcp_registration_CF1s")]
public class ListJsonFile : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_registration_CF1> repository;

  public ListJsonFile(IAsyncRepository<slcp_registration_CF1> repository)
  {
    this.repository = repository;
  }

  /// <summary>
  /// List all slcp_registration_CF1s as a JSON file
  /// </summary>
  [HttpGet("api/[namespace]/Json")]
  public override async Task<ActionResult> HandleAsync(
      CancellationToken cancellationToken = default)
  {
    var result = (await repository.ListAllAsync(cancellationToken)).ToList();

    var streamData = JsonSerializer.SerializeToUtf8Bytes(result);
    return File(streamData, "text/json", "slcp_registration_cf1.json");
  }
}

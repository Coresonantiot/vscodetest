using System.Text.Json;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employees;

[Tags("slcp_employees")]
public class ListJsonFile : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_employee> repository;

  public ListJsonFile(IAsyncRepository<slcp_employee> repository)
  {
    this.repository = repository;
  }

  /// <summary>
  /// List all slcp_employees as a JSON file
  /// </summary>
  [HttpGet("api/[namespace]/Json")]
  public override async Task<ActionResult> HandleAsync(
      CancellationToken cancellationToken = default)
  {
    var result = (await repository.ListAllAsync(cancellationToken)).ToList();

    var streamData = JsonSerializer.SerializeToUtf8Bytes(result);
    return File(streamData, "text/json", "slcp_employee.json");
  }
}

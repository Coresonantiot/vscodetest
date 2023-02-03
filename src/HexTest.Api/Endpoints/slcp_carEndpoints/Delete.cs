using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

[Tags("slcp_cars")]
public class Delete : EndpointBaseAsync
    .WithRequest<Deleteslcp_carRequest>
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_car> _repository;

  public Delete(IAsyncRepository<slcp_car> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Deletes an slcp_car
  /// </summary>
  [HttpDelete("api/[namespace]/{id}")]
  public override async Task<ActionResult> HandleAsync([FromRoute] Deleteslcp_carRequest request, CancellationToken cancellationToken)
  {
    var slcp_car = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_car is null)
    {
      return NotFound(request.Id);
    }

    await _repository.DeleteAsync(slcp_car, cancellationToken);

    // see https://restfulapi.net/http-methods/#delete
    return NoContent();
  }
}

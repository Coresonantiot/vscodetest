using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_registration_CF1Aggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_registration_CF1s;

[Tags("slcp_registration_CF1s")]
public class Delete : EndpointBaseAsync
    .WithRequest<Deleteslcp_registration_CF1Request>
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_registration_CF1> _repository;

  public Delete(IAsyncRepository<slcp_registration_CF1> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Deletes an slcp_registration_CF1
  /// </summary>
  [HttpDelete("api/[namespace]/{id}")]
  public override async Task<ActionResult> HandleAsync([FromRoute] Deleteslcp_registration_CF1Request request, CancellationToken cancellationToken)
  {
    var slcp_registration_CF1 = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_registration_CF1 is null)
    {
      return NotFound(request.Id);
    }

    await _repository.DeleteAsync(slcp_registration_CF1, cancellationToken);

    // see https://restfulapi.net/http-methods/#delete
    return NoContent();
  }
}

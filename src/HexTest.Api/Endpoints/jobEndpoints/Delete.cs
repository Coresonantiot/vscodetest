using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.jobAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.jobs;

[Tags("jobs")]
public class Delete : EndpointBaseAsync
    .WithRequest<DeletejobRequest>
    .WithActionResult
{
  private readonly IAsyncRepository<job> _repository;

  public Delete(IAsyncRepository<job> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Deletes an job
  /// </summary>
  [HttpDelete("api/[namespace]/{id}")]
  public override async Task<ActionResult> HandleAsync([FromRoute] DeletejobRequest request, CancellationToken cancellationToken)
  {
    var job = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (job is null)
    {
      return NotFound(request.Id);
    }

    await _repository.DeleteAsync(job, cancellationToken);

    // see https://restfulapi.net/http-methods/#delete
    return NoContent();
  }
}

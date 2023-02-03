using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_departmentAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_departments;

[Tags("slcp_departments")]
public class Delete : EndpointBaseAsync
    .WithRequest<Deleteslcp_departmentRequest>
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_department> _repository;

  public Delete(IAsyncRepository<slcp_department> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Deletes an slcp_department
  /// </summary>
  [HttpDelete("api/[namespace]/{id}")]
  public override async Task<ActionResult> HandleAsync([FromRoute] Deleteslcp_departmentRequest request, CancellationToken cancellationToken)
  {
    var slcp_department = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_department is null)
    {
      return NotFound(request.Id);
    }

    await _repository.DeleteAsync(slcp_department, cancellationToken);

    // see https://restfulapi.net/http-methods/#delete
    return NoContent();
  }
}

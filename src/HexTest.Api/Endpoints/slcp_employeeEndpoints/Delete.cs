using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employees;

[Tags("slcp_employees")]
public class Delete : EndpointBaseAsync
    .WithRequest<Deleteslcp_employeeRequest>
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_employee> _repository;

  public Delete(IAsyncRepository<slcp_employee> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Deletes an slcp_employee
  /// </summary>
  [HttpDelete("api/[namespace]/{id}")]
  public override async Task<ActionResult> HandleAsync([FromRoute] Deleteslcp_employeeRequest request, CancellationToken cancellationToken)
  {
    var slcp_employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_employee is null)
    {
      return NotFound(request.Id);
    }

    await _repository.DeleteAsync(slcp_employee, cancellationToken);

    // see https://restfulapi.net/http-methods/#delete
    return NoContent();
  }
}

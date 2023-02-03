using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_employee_department_mapAggregate;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Core.slcp_departmentAggregate;
//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employee_department_maps;

[Tags("slcp_employee_department_maps")]
public class Delete : EndpointBaseAsync
    .WithRequest<Deleteslcp_employee_department_mapRequest>
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_employee_department_map> _repository;

  public Delete(IAsyncRepository<slcp_employee_department_map> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Deletes an slcp_employee_department_map
  /// </summary>
  [HttpDelete("api/[namespace]/{id}")]
  public override async Task<ActionResult> HandleAsync([FromRoute] Deleteslcp_employee_department_mapRequest request, CancellationToken cancellationToken)
  {
    var slcp_employee_department_map = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_employee_department_map is null)
    {
      return NotFound(request.Id);
    }

    await _repository.DeleteAsync(slcp_employee_department_map, cancellationToken);

    // see https://restfulapi.net/http-methods/#delete
    return NoContent();
  }
}

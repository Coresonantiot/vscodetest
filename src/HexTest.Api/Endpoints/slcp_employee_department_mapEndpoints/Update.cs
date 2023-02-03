using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_employee_department_mapAggregate;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Core.slcp_departmentAggregate;
//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employee_department_maps;

[Tags("slcp_employee_department_maps")]
public class Update : EndpointBaseAsync
    .WithRequest<Updateslcp_employee_department_mapCommand>
    .WithActionResult<Updatedslcp_employee_department_mapResult>
{
  private readonly IAsyncRepository<slcp_employee_department_map> _repository;
  private readonly IMapper _mapper;

  public Update(IAsyncRepository<slcp_employee_department_map> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Updates an existing slcp_employee_department_map
  /// </summary>
  [HttpPut("api/[namespace]")]
  public override async Task<ActionResult<Updatedslcp_employee_department_mapResult>> HandleAsync([FromBody] Updateslcp_employee_department_mapCommand request, CancellationToken cancellationToken)
  {
    var slcp_employee_department_map = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_employee_department_map is null) return NotFound();

    _mapper.Map(request, slcp_employee_department_map);
    await _repository.UpdateAsync(slcp_employee_department_map, cancellationToken);

    var result = _mapper.Map<Updatedslcp_employee_department_mapResult>(slcp_employee_department_map);
    return result;
  }
}

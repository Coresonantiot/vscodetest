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
public class Get : EndpointBaseAsync
      .WithRequest<int>
      .WithActionResult<slcp_employee_department_mapResult>
{
  private readonly IAsyncRepository<slcp_employee_department_map> _repository;
  private readonly IMapper _mapper;

  public Get(IAsyncRepository<slcp_employee_department_map> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Get a specific slcp_employee_department_map
  /// </summary>
  [HttpGet("api/[namespace]/{id}", Name = "[namespace]_[controller]")]
  public override async Task<ActionResult<slcp_employee_department_mapResult>> HandleAsync(int id, CancellationToken cancellationToken)
  {
    var slcp_employee_department_map = await _repository.GetByIdAsync(id, cancellationToken);

    if (slcp_employee_department_map is null) return NotFound();

    var result = _mapper.Map<slcp_employee_department_mapResult>(slcp_employee_department_map);

    return result;
  }
}

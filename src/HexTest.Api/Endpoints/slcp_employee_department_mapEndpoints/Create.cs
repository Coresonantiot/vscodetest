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
public class Create : EndpointBaseAsync
    .WithRequest<Createslcp_employee_department_mapCommand>
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_employee_department_map> _repository;
  private readonly IMapper _mapper;

  public Create(IAsyncRepository<slcp_employee_department_map> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Creates a new slcp_employee_department_map
  /// </summary>
  [HttpPost("api/[namespace]")]
  public override async Task<ActionResult> HandleAsync([FromBody] Createslcp_employee_department_mapCommand request, CancellationToken cancellationToken)
  {
    var slcp_employee_department_map = new slcp_employee_department_map();
    _mapper.Map(request, slcp_employee_department_map);
    await _repository.AddAsync(slcp_employee_department_map, cancellationToken);

    var result = _mapper.Map<Createslcp_employee_department_mapResult>(slcp_employee_department_map);
    return CreatedAtRoute("slcp_employee_department_maps_Get", new { id = result.Id }, result);
  }
}

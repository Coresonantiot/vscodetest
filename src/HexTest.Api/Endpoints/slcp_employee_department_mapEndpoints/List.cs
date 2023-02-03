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
public class List : EndpointBaseAsync
    .WithRequest<slcp_employee_department_mapListRequest>
    .WithResult<IEnumerable<slcp_employee_department_mapListResult>>
{
  private readonly IAsyncRepository<slcp_employee_department_map> repository;
  private readonly IMapper mapper;

  public List(
      IAsyncRepository<slcp_employee_department_map> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all slcp_employee_department_maps
  /// </summary>
  [HttpGet("api/[namespace]")]
  public override async Task<IEnumerable<slcp_employee_department_mapListResult>> HandleAsync(
      [FromQuery] slcp_employee_department_mapListRequest request,
      CancellationToken cancellationToken = default)
  {
    if (request.PerPage == 0)
    {
      request.PerPage = 10;
    }
    if (request.Page == 0)
    {
      request.Page = 1;
    }
    var result = (await repository.ListAllAsync(request.PerPage, request.Page, cancellationToken))
        .Select(i => mapper.Map<slcp_employee_department_mapListResult>(i));

    return result;
  }
}

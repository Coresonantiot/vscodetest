using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employees;

[Tags("slcp_employees")]
public class List : EndpointBaseAsync
    .WithRequest<slcp_employeeListRequest>
    .WithResult<IEnumerable<slcp_employeeListResult>>
{
  private readonly IAsyncRepository<slcp_employee> repository;
  private readonly IMapper mapper;

  public List(
      IAsyncRepository<slcp_employee> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all slcp_employees
  /// </summary>
  [HttpGet("api/[namespace]")]
  public override async Task<IEnumerable<slcp_employeeListResult>> HandleAsync(
      [FromQuery] slcp_employeeListRequest request,
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
        .Select(i => mapper.Map<slcp_employeeListResult>(i));

    return result;
  }
}

using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_departmentAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_departments;

[Tags("slcp_departments")]
public class List : EndpointBaseAsync
    .WithRequest<slcp_departmentListRequest>
    .WithResult<IEnumerable<slcp_departmentListResult>>
{
  private readonly IAsyncRepository<slcp_department> repository;
  private readonly IMapper mapper;

  public List(
      IAsyncRepository<slcp_department> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all slcp_departments
  /// </summary>
  [HttpGet("api/[namespace]")]
  public override async Task<IEnumerable<slcp_departmentListResult>> HandleAsync(
      [FromQuery] slcp_departmentListRequest request,
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
        .Select(i => mapper.Map<slcp_departmentListResult>(i));

    return result;
  }
}

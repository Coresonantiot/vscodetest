using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_departmentAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_departments;

[Tags("slcp_departments")]
public class GetByQuery : EndpointBaseAsync
    .WithRequest<slcp_departmentGetByQueryRequest>
    .WithResult<IEnumerable<slcp_departmentGetByQueryResult>>
{
  private readonly IAsyncRepository<slcp_department> repository;
  private readonly IMapper mapper;

  public GetByQuery(
      IAsyncRepository<slcp_department> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all slcp_departments
  /// </summary>
  [HttpGet("api/[namespace]/GetByQuery")]
  public override async Task<IEnumerable<slcp_departmentGetByQueryResult>> HandleAsync(
      [FromQuery] slcp_departmentGetByQueryRequest request,
      CancellationToken cancellationToken = default)
  {
        string includeProperties = request.includeProperties != null ? request.includeProperties : "";

        var result = (await repository.GetAsync(filter: request.Id == 0 ? null : obj => obj.Id == request.Id, includeProperties: includeProperties))
            .Select(i => mapper.Map<slcp_departmentGetByQueryResult>(i));

        return result;
  }
}
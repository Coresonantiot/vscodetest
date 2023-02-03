using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employees;

[Tags("slcp_employees")]
public class GetByQuery : EndpointBaseAsync
    .WithRequest<slcp_employeeGetByQueryRequest>
    .WithResult<IEnumerable<slcp_employeeGetByQueryResult>>
{
  private readonly IAsyncRepository<slcp_employee> repository;
  private readonly IMapper mapper;

  public GetByQuery(
      IAsyncRepository<slcp_employee> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all slcp_employees
  /// </summary>
  [HttpGet("api/[namespace]/GetByQuery")]
  public override async Task<IEnumerable<slcp_employeeGetByQueryResult>> HandleAsync(
      [FromQuery] slcp_employeeGetByQueryRequest request,
      CancellationToken cancellationToken = default)
  {
        string includeProperties = request.includeProperties != null ? request.includeProperties : "";

        var result = (await repository.GetAsync(filter: request.Id == 0 ? null : obj => obj.Id == request.Id, includeProperties: includeProperties))
            .Select(i => mapper.Map<slcp_employeeGetByQueryResult>(i));

        return result;
  }
}
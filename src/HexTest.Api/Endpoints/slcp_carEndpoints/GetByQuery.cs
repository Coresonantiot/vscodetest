using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

[Tags("slcp_cars")]
public class GetByQuery : EndpointBaseAsync
    .WithRequest<slcp_carGetByQueryRequest>
    .WithResult<IEnumerable<slcp_carGetByQueryResult>>
{
  private readonly IAsyncRepository<slcp_car> repository;
  private readonly IMapper mapper;

  public GetByQuery(
      IAsyncRepository<slcp_car> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all slcp_cars
  /// </summary>
  [HttpGet("api/[namespace]/GetByQuery")]
  public override async Task<IEnumerable<slcp_carGetByQueryResult>> HandleAsync(
      [FromQuery] slcp_carGetByQueryRequest request,
      CancellationToken cancellationToken = default)
  {
        string includeProperties = request.includeProperties != null ? request.includeProperties : "";

        var result = (await repository.GetAsync(filter: request.Id == 0 ? null : obj => obj.Id == request.Id, includeProperties: includeProperties))
            .Select(i => mapper.Map<slcp_carGetByQueryResult>(i));

        return result;
  }
}
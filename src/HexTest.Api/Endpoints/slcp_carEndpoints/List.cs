using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

[Tags("slcp_cars")]
public class List : EndpointBaseAsync
    .WithRequest<slcp_carListRequest>
    .WithResult<IEnumerable<slcp_carListResult>>
{
  private readonly IAsyncRepository<slcp_car> repository;
  private readonly IMapper mapper;

  public List(
      IAsyncRepository<slcp_car> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all slcp_cars
  /// </summary>
  [HttpGet("api/[namespace]")]
  public override async Task<IEnumerable<slcp_carListResult>> HandleAsync(
      [FromQuery] slcp_carListRequest request,
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
        .Select(i => mapper.Map<slcp_carListResult>(i));

    return result;
  }
}

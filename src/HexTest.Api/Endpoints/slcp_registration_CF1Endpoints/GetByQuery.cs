using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_registration_CF1Aggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_registration_CF1s;

[Tags("slcp_registration_CF1s")]
public class GetByQuery : EndpointBaseAsync
    .WithRequest<slcp_registration_CF1GetByQueryRequest>
    .WithResult<IEnumerable<slcp_registration_CF1GetByQueryResult>>
{
  private readonly IAsyncRepository<slcp_registration_CF1> repository;
  private readonly IMapper mapper;

  public GetByQuery(
      IAsyncRepository<slcp_registration_CF1> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all slcp_registration_CF1s
  /// </summary>
  [HttpGet("api/[namespace]/GetByQuery")]
  public override async Task<IEnumerable<slcp_registration_CF1GetByQueryResult>> HandleAsync(
      [FromQuery] slcp_registration_CF1GetByQueryRequest request,
      CancellationToken cancellationToken = default)
  {
        string includeProperties = request.includeProperties != null ? request.includeProperties : "";

        var result = (await repository.GetAsync(filter: request.Id == 0 ? null : obj => obj.Id == request.Id, includeProperties: includeProperties))
            .Select(i => mapper.Map<slcp_registration_CF1GetByQueryResult>(i));

        return result;
  }
}
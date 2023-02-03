using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.jobAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.jobs;

[Tags("jobs")]
public class GetByQuery : EndpointBaseAsync
    .WithRequest<jobGetByQueryRequest>
    .WithResult<IEnumerable<jobGetByQueryResult>>
{
  private readonly IAsyncRepository<job> repository;
  private readonly IMapper mapper;

  public GetByQuery(
      IAsyncRepository<job> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all jobs
  /// </summary>
  [HttpGet("api/[namespace]/GetByQuery")]
  public override async Task<IEnumerable<jobGetByQueryResult>> HandleAsync(
      [FromQuery] jobGetByQueryRequest request,
      CancellationToken cancellationToken = default)
  {
        string includeProperties = request.includeProperties != null ? request.includeProperties : "";

        var result = (await repository.GetAsync(filter: request.Id == 0 ? null : obj => obj.Id == request.Id, includeProperties: includeProperties))
            .Select(i => mapper.Map<jobGetByQueryResult>(i));

        return result;
  }
}
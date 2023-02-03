using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_registration_CF1Aggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_registration_CF1s;

[Tags("slcp_registration_CF1s")]
public class List : EndpointBaseAsync
    .WithRequest<slcp_registration_CF1ListRequest>
    .WithResult<IEnumerable<slcp_registration_CF1ListResult>>
{
  private readonly IAsyncRepository<slcp_registration_CF1> repository;
  private readonly IMapper mapper;

  public List(
      IAsyncRepository<slcp_registration_CF1> repository,
      IMapper mapper)
  {
    this.repository = repository;
    this.mapper = mapper;
  }

  /// <summary>
  /// List all slcp_registration_CF1s
  /// </summary>
  [HttpGet("api/[namespace]")]
  public override async Task<IEnumerable<slcp_registration_CF1ListResult>> HandleAsync(
      [FromQuery] slcp_registration_CF1ListRequest request,
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
        .Select(i => mapper.Map<slcp_registration_CF1ListResult>(i));

    return result;
  }
}

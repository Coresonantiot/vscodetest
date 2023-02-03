using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_registration_CF1Aggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_registration_CF1s;

[Tags("slcp_registration_CF1s")]
public class Get : EndpointBaseAsync
      .WithRequest<int>
      .WithActionResult<slcp_registration_CF1Result>
{
  private readonly IAsyncRepository<slcp_registration_CF1> _repository;
  private readonly IMapper _mapper;

  public Get(IAsyncRepository<slcp_registration_CF1> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Get a specific slcp_registration_CF1
  /// </summary>
  [HttpGet("api/[namespace]/{id}", Name = "[namespace]_[controller]")]
  public override async Task<ActionResult<slcp_registration_CF1Result>> HandleAsync(int id, CancellationToken cancellationToken)
  {
    var slcp_registration_cf1 = await _repository.GetByIdAsync(id, cancellationToken);

    if (slcp_registration_cf1 is null) return NotFound();

    var result = _mapper.Map<slcp_registration_CF1Result>(slcp_registration_cf1);

    return result;
  }
}

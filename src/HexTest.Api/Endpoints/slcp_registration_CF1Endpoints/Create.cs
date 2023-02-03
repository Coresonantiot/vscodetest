using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_registration_CF1Aggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_registration_CF1s;

[Tags("slcp_registration_CF1s")]
public class Create : EndpointBaseAsync
    .WithRequest<Createslcp_registration_CF1Command>
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_registration_CF1> _repository;
  private readonly IMapper _mapper;

  public Create(IAsyncRepository<slcp_registration_CF1> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Creates a new slcp_registration_CF1
  /// </summary>
  [HttpPost("api/[namespace]")]
  public override async Task<ActionResult> HandleAsync([FromBody] Createslcp_registration_CF1Command request, CancellationToken cancellationToken)
  {
    var slcp_registration_cf1 = new slcp_registration_CF1();
    _mapper.Map(request, slcp_registration_cf1);
    await _repository.AddAsync(slcp_registration_cf1, cancellationToken);

    var result = _mapper.Map<Createslcp_registration_CF1Result>(slcp_registration_cf1);
    return CreatedAtRoute("slcp_registration_CF1s_Get", new { id = result.Id }, result);
  }
}

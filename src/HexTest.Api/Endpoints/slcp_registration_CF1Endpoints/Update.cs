using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_registration_CF1Aggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_registration_CF1s;

[Tags("slcp_registration_CF1s")]
public class Update : EndpointBaseAsync
    .WithRequest<Updateslcp_registration_CF1Command>
    .WithActionResult<Updatedslcp_registration_CF1Result>
{
  private readonly IAsyncRepository<slcp_registration_CF1> _repository;
  private readonly IMapper _mapper;

  public Update(IAsyncRepository<slcp_registration_CF1> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Updates an existing slcp_registration_CF1
  /// </summary>
  [HttpPut("api/[namespace]")]
  public override async Task<ActionResult<Updatedslcp_registration_CF1Result>> HandleAsync([FromBody] Updateslcp_registration_CF1Command request, CancellationToken cancellationToken)
  {
    var slcp_registration_cf1 = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_registration_cf1 is null) return NotFound();

    _mapper.Map(request, slcp_registration_cf1);
    await _repository.UpdateAsync(slcp_registration_cf1, cancellationToken);

    var result = _mapper.Map<Updatedslcp_registration_CF1Result>(slcp_registration_cf1);
    return result;
  }
}

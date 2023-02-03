using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_registration_CF1Aggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_registration_CF1s;

[Tags("slcp_registration_CF1s")]
public class UpdateById : EndpointBaseAsync
    .WithRequest<Updateslcp_registration_CF1CommandById>
    .WithActionResult<Updatedslcp_registration_CF1ByIdResult>
{
  private readonly IAsyncRepository<slcp_registration_CF1> _repository;
  private readonly IMapper _mapper;

  public UpdateById(IAsyncRepository<slcp_registration_CF1> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Updates an existing slcp_registration_CF1
  /// </summary>
  [HttpPut("api/[namespace]/{id}")]
  public override async Task<ActionResult<Updatedslcp_registration_CF1ByIdResult>> HandleAsync([FromMultiSource]Updateslcp_registration_CF1CommandById request,
    CancellationToken cancellationToken)
  {
    var slcp_registration_cf1 = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_registration_cf1 is null) return NotFound();

     _mapper.Map(request, slcp_registration_cf1);
    await _repository.UpdateAsync(slcp_registration_cf1, cancellationToken);

    var result = _mapper.Map<Updatedslcp_registration_CF1ByIdResult>(slcp_registration_cf1);
    return result;
  }
}

using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

[Tags("slcp_cars")]
public class Update : EndpointBaseAsync
    .WithRequest<Updateslcp_carCommand>
    .WithActionResult<Updatedslcp_carResult>
{
  private readonly IAsyncRepository<slcp_car> _repository;
  private readonly IMapper _mapper;

  public Update(IAsyncRepository<slcp_car> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Updates an existing slcp_car
  /// </summary>
  [HttpPut("api/[namespace]")]
  public override async Task<ActionResult<Updatedslcp_carResult>> HandleAsync([FromBody] Updateslcp_carCommand request, CancellationToken cancellationToken)
  {
    var slcp_car = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_car is null) return NotFound();

    _mapper.Map(request, slcp_car);
    await _repository.UpdateAsync(slcp_car, cancellationToken);

    var result = _mapper.Map<Updatedslcp_carResult>(slcp_car);
    return result;
  }
}

using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

[Tags("slcp_cars")]
public class UpdateById : EndpointBaseAsync
    .WithRequest<Updateslcp_carCommandById>
    .WithActionResult<Updatedslcp_carByIdResult>
{
  private readonly IAsyncRepository<slcp_car> _repository;
  private readonly IMapper _mapper;

  public UpdateById(IAsyncRepository<slcp_car> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Updates an existing slcp_car
  /// </summary>
  [HttpPut("api/[namespace]/{id}")]
  public override async Task<ActionResult<Updatedslcp_carByIdResult>> HandleAsync([FromMultiSource]Updateslcp_carCommandById request,
    CancellationToken cancellationToken)
  {
    var slcp_car = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_car is null) return NotFound();

     _mapper.Map(request, slcp_car);
    await _repository.UpdateAsync(slcp_car, cancellationToken);

    var result = _mapper.Map<Updatedslcp_carByIdResult>(slcp_car);
    return result;
  }
}

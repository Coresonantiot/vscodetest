using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

[Tags("slcp_cars")]
public class Create : EndpointBaseAsync
    .WithRequest<Createslcp_carCommand>
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_car> _repository;
  private readonly IMapper _mapper;

  public Create(IAsyncRepository<slcp_car> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Creates a new slcp_car
  /// </summary>
  [HttpPost("api/[namespace]")]
  public override async Task<ActionResult> HandleAsync([FromBody] Createslcp_carCommand request, CancellationToken cancellationToken)
  {
    var slcp_car = new slcp_car();
    _mapper.Map(request, slcp_car);
    await _repository.AddAsync(slcp_car, cancellationToken);

    var result = _mapper.Map<Createslcp_carResult>(slcp_car);
    return CreatedAtRoute("slcp_cars_Get", new { id = result.Id }, result);
  }
}

using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_carAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_cars;

[Tags("slcp_cars")]
public class Get : EndpointBaseAsync
      .WithRequest<int>
      .WithActionResult<slcp_carResult>
{
  private readonly IAsyncRepository<slcp_car> _repository;
  private readonly IMapper _mapper;

  public Get(IAsyncRepository<slcp_car> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Get a specific slcp_car
  /// </summary>
  [HttpGet("api/[namespace]/{id}", Name = "[namespace]_[controller]")]
  public override async Task<ActionResult<slcp_carResult>> HandleAsync(int id, CancellationToken cancellationToken)
  {
    var slcp_car = await _repository.GetByIdAsync(id, cancellationToken);

    if (slcp_car is null) return NotFound();

    var result = _mapper.Map<slcp_carResult>(slcp_car);

    return result;
  }
}

using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.jobAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.jobs;

[Tags("jobs")]
public class Get : EndpointBaseAsync
      .WithRequest<int>
      .WithActionResult<jobResult>
{
  private readonly IAsyncRepository<job> _repository;
  private readonly IMapper _mapper;

  public Get(IAsyncRepository<job> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Get a specific job
  /// </summary>
  [HttpGet("api/[namespace]/{id}", Name = "[namespace]_[controller]")]
  public override async Task<ActionResult<jobResult>> HandleAsync(int id, CancellationToken cancellationToken)
  {
    var job = await _repository.GetByIdAsync(id, cancellationToken);

    if (job is null) return NotFound();

    var result = _mapper.Map<jobResult>(job);

    return result;
  }
}

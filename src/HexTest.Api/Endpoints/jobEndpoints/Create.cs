using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.jobAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.jobs;

[Tags("jobs")]
public class Create : EndpointBaseAsync
    .WithRequest<CreatejobCommand>
    .WithActionResult
{
  private readonly IAsyncRepository<job> _repository;
  private readonly IMapper _mapper;

  public Create(IAsyncRepository<job> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Creates a new job
  /// </summary>
  [HttpPost("api/[namespace]")]
  public override async Task<ActionResult> HandleAsync([FromBody] CreatejobCommand request, CancellationToken cancellationToken)
  {
    var job = new job();
    _mapper.Map(request, job);
    await _repository.AddAsync(job, cancellationToken);

    var result = _mapper.Map<CreatejobResult>(job);
    return CreatedAtRoute("jobs_Get", new { id = result.Id }, result);
  }
}

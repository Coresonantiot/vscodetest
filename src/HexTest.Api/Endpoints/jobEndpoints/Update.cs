using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.jobAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.jobs;

[Tags("jobs")]
public class Update : EndpointBaseAsync
    .WithRequest<UpdatejobCommand>
    .WithActionResult<UpdatedjobResult>
{
  private readonly IAsyncRepository<job> _repository;
  private readonly IMapper _mapper;

  public Update(IAsyncRepository<job> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Updates an existing job
  /// </summary>
  [HttpPut("api/[namespace]")]
  public override async Task<ActionResult<UpdatedjobResult>> HandleAsync([FromBody] UpdatejobCommand request, CancellationToken cancellationToken)
  {
    var job = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (job is null) return NotFound();

    _mapper.Map(request, job);
    await _repository.UpdateAsync(job, cancellationToken);

    var result = _mapper.Map<UpdatedjobResult>(job);
    return result;
  }
}

using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_departmentAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_departments;

[Tags("slcp_departments")]
public class Create : EndpointBaseAsync
    .WithRequest<Createslcp_departmentCommand>
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_department> _repository;
  private readonly IMapper _mapper;

  public Create(IAsyncRepository<slcp_department> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Creates a new slcp_department
  /// </summary>
  [HttpPost("api/[namespace]")]
  public override async Task<ActionResult> HandleAsync([FromBody] Createslcp_departmentCommand request, CancellationToken cancellationToken)
  {
    var slcp_department = new slcp_department();
    _mapper.Map(request, slcp_department);
    await _repository.AddAsync(slcp_department, cancellationToken);

    var result = _mapper.Map<Createslcp_departmentResult>(slcp_department);
    return CreatedAtRoute("slcp_departments_Get", new { id = result.Id }, result);
  }
}

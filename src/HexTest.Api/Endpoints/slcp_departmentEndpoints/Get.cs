using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_departmentAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_departments;

[Tags("slcp_departments")]
public class Get : EndpointBaseAsync
      .WithRequest<int>
      .WithActionResult<slcp_departmentResult>
{
  private readonly IAsyncRepository<slcp_department> _repository;
  private readonly IMapper _mapper;

  public Get(IAsyncRepository<slcp_department> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Get a specific slcp_department
  /// </summary>
  [HttpGet("api/[namespace]/{id}", Name = "[namespace]_[controller]")]
  public override async Task<ActionResult<slcp_departmentResult>> HandleAsync(int id, CancellationToken cancellationToken)
  {
    var slcp_department = await _repository.GetByIdAsync(id, cancellationToken);

    if (slcp_department is null) return NotFound();

    var result = _mapper.Map<slcp_departmentResult>(slcp_department);

    return result;
  }
}

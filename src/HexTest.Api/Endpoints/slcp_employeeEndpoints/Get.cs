using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employees;

[Tags("slcp_employees")]
public class Get : EndpointBaseAsync
      .WithRequest<int>
      .WithActionResult<slcp_employeeResult>
{
  private readonly IAsyncRepository<slcp_employee> _repository;
  private readonly IMapper _mapper;

  public Get(IAsyncRepository<slcp_employee> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Get a specific slcp_employee
  /// </summary>
  [HttpGet("api/[namespace]/{id}", Name = "[namespace]_[controller]")]
  public override async Task<ActionResult<slcp_employeeResult>> HandleAsync(int id, CancellationToken cancellationToken)
  {
    var slcp_employee = await _repository.GetByIdAsync(id, cancellationToken);

    if (slcp_employee is null) return NotFound();

    var result = _mapper.Map<slcp_employeeResult>(slcp_employee);

    return result;
  }
}

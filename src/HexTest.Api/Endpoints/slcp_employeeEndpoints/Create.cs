using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employees;

[Tags("slcp_employees")]
public class Create : EndpointBaseAsync
    .WithRequest<Createslcp_employeeCommand>
    .WithActionResult
{
  private readonly IAsyncRepository<slcp_employee> _repository;
  private readonly IMapper _mapper;

  public Create(IAsyncRepository<slcp_employee> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Creates a new slcp_employee
  /// </summary>
  [HttpPost("api/[namespace]")]
  public override async Task<ActionResult> HandleAsync([FromBody] Createslcp_employeeCommand request, CancellationToken cancellationToken)
  {
    var slcp_employee = new slcp_employee();
    _mapper.Map(request, slcp_employee);
    await _repository.AddAsync(slcp_employee, cancellationToken);

    var result = _mapper.Map<Createslcp_employeeResult>(slcp_employee);
    return CreatedAtRoute("slcp_employees_Get", new { id = result.Id }, result);
  }
}

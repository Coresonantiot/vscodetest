using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employees;

[Tags("slcp_employees")]
public class Update : EndpointBaseAsync
    .WithRequest<Updateslcp_employeeCommand>
    .WithActionResult<Updatedslcp_employeeResult>
{
  private readonly IAsyncRepository<slcp_employee> _repository;
  private readonly IMapper _mapper;

  public Update(IAsyncRepository<slcp_employee> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Updates an existing slcp_employee
  /// </summary>
  [HttpPut("api/[namespace]")]
  public override async Task<ActionResult<Updatedslcp_employeeResult>> HandleAsync([FromBody] Updateslcp_employeeCommand request, CancellationToken cancellationToken)
  {
    var slcp_employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_employee is null) return NotFound();

    _mapper.Map(request, slcp_employee);
    await _repository.UpdateAsync(slcp_employee, cancellationToken);

    var result = _mapper.Map<Updatedslcp_employeeResult>(slcp_employee);
    return result;
  }
}

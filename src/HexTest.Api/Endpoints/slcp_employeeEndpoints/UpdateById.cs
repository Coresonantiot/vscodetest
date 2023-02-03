using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_employeeAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_employees;

[Tags("slcp_employees")]
public class UpdateById : EndpointBaseAsync
    .WithRequest<Updateslcp_employeeCommandById>
    .WithActionResult<Updatedslcp_employeeByIdResult>
{
  private readonly IAsyncRepository<slcp_employee> _repository;
  private readonly IMapper _mapper;

  public UpdateById(IAsyncRepository<slcp_employee> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Updates an existing slcp_employee
  /// </summary>
  [HttpPut("api/[namespace]/{id}")]
  public override async Task<ActionResult<Updatedslcp_employeeByIdResult>> HandleAsync([FromMultiSource]Updateslcp_employeeCommandById request,
    CancellationToken cancellationToken)
  {
    var slcp_employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_employee is null) return NotFound();

     _mapper.Map(request, slcp_employee);
    await _repository.UpdateAsync(slcp_employee, cancellationToken);

    var result = _mapper.Map<Updatedslcp_employeeByIdResult>(slcp_employee);
    return result;
  }
}

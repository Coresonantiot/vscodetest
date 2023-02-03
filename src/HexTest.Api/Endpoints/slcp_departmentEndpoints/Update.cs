using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HexTest.SharedKernel.Interfaces;
using HexTest.SharedKernel;
using HexTest.Core.slcp_departmentAggregate;
		//<#AddNamespaces#>

namespace HexTest.Api.Endpoints.slcp_departments;

[Tags("slcp_departments")]
public class Update : EndpointBaseAsync
    .WithRequest<Updateslcp_departmentCommand>
    .WithActionResult<Updatedslcp_departmentResult>
{
  private readonly IAsyncRepository<slcp_department> _repository;
  private readonly IMapper _mapper;

  public Update(IAsyncRepository<slcp_department> repository,
      IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  /// <summary>
  /// Updates an existing slcp_department
  /// </summary>
  [HttpPut("api/[namespace]")]
  public override async Task<ActionResult<Updatedslcp_departmentResult>> HandleAsync([FromBody] Updateslcp_departmentCommand request, CancellationToken cancellationToken)
  {
    var slcp_department = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (slcp_department is null) return NotFound();

    _mapper.Map(request, slcp_department);
    await _repository.UpdateAsync(slcp_department, cancellationToken);

    var result = _mapper.Map<Updatedslcp_departmentResult>(slcp_department);
    return result;
  }
}

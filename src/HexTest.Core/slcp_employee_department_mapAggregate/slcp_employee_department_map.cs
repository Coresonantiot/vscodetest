using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using HexTest.SharedKernel;
using HexTest.SharedKernel.Interfaces;
using HexTest.Core.slcp_employee_department_mapAggregate.Events;

namespace HexTest.Core.slcp_employee_department_mapAggregate;

public class slcp_employee_department_map : BaseEntity, IAggregateRoot
{
	[Required]
public int slcp_employeeId { get; set; }

	[Required]
public int slcp_departmentId { get; set; }

}//End of Class

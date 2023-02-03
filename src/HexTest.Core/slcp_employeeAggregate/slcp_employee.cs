using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using HexTest.SharedKernel;
using HexTest.SharedKernel.Interfaces;
using HexTest.Core.slcp_employeeAggregate.Events;
//ReferenceFiles

namespace HexTest.Core.slcp_employeeAggregate;

public class slcp_employee : BaseEntity
{
	public string? slcp_name { get; set; }

	public string? slcp_Joinmonth { get; set; }

	[Required]
	public string slcp_emp_code { get; set; }

	public string? slcp_address { get; set; }

}//End of Class

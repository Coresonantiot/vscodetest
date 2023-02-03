using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using HexTest.SharedKernel;
using HexTest.SharedKernel.Interfaces;
using HexTest.Core.slcp_registration_CF1Aggregate.Events;
//ReferenceFiles

namespace HexTest.Core.slcp_registration_CF1Aggregate;

public class slcp_registration_CF1_slcp_department : BaseEntity
{
	[Required]
	public string slcp_dept_name { get; set; }

	[Required]
	public string slcp_dept_code { get; set; }

}//End of Class

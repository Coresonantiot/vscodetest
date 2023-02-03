using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using HexTest.SharedKernel;
using HexTest.SharedKernel.Interfaces;
using HexTest.Core.slcp_carAggregate.Events;
//ReferenceFiles

namespace HexTest.Core.slcp_carAggregate;

public class slcp_engine : BaseEntity
{
	[Required]
	public string slcp_engine_number { get; set; }

	public string? slcp_type { get; set; }

	public string? slcp_fuel_type { get; set; }

}//End of Class

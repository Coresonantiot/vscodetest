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

public class slcp_wheel : BaseEntity
{
	[Required]
	public string slcp_type { get; set; }

	public string? slcp_diameter { get; set; }

	public string? slcp_heat_resistance { get; set; }

	public int slcp_carId { get; set; }
}//End of Class

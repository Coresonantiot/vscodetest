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

public class slcp_car : BaseEntity, IAggregateRoot
{
	[Required]
	public string slcp_colour { get; set; }

	public string? slcp_isshipped { get; set; }

		public virtual slcp_engine slcp_engine { get; set; }

		public int slcp_engineId { get; set; }

		public virtual ICollection<slcp_wheel> slcp_wheel { get; set; }

}//End of Class

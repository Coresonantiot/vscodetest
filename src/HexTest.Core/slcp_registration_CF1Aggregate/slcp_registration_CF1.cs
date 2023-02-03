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

namespace HexTest.Core.slcp_registration_CF1Aggregate;

public class slcp_registration_CF1 : BaseEntity, IAggregateRoot
{
		public virtual slcp_registration_CF1_slcp_employee slcp_registration_CF1_slcp_employee{ get; set; }

		public virtual slcp_registration_CF1_slcp_department slcp_registration_CF1_slcp_department{ get; set; }

}//End of Class

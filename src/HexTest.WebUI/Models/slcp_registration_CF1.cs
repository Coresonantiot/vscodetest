using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HexTest{
	public class slcp_registration_CF1
	{
	[Required]
public int Id { get; set; }

		public slcp_registration_CF1_slcp_employee slcp_registration_CF1_slcp_employee{ get; set; }

		public slcp_registration_CF1_slcp_department slcp_registration_CF1_slcp_department{ get; set; }

}	//End of Class
}//End of Namespace

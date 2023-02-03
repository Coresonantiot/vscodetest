using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HexTest{
	public class slcp_registration_CF1_slcp_employee
	{
	[Required]
		public int Id { get; set; }

	public string? slcp_name { get; set; }		

	[Required]
	public string slcp_emp_code { get; set; }		

}	//End of Class
}//End of Namespace

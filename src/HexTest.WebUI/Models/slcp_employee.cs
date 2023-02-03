using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HexTest.WebUI.Models{
	public class slcp_employee
	{
	[Required]
	public int Id { get; set; }

	public string? slcp_name { get; set; }		

	public string? slcp_Joinmonth { get; set; }		

	[Required]
	public string slcp_emp_code { get; set; }		

	public string? slcp_address { get; set; }		

}	//End of Class
}//End of Namespace

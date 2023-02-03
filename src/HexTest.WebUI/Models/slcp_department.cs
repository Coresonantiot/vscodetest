using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HexTest.WebUI.Models{
	public class slcp_department
	{
	[Required]
	public int Id { get; set; }

	[Required]
	public string slcp_dept_name { get; set; }		

	[Required]
	public string slcp_dept_code { get; set; }		

}	//End of Class
}//End of Namespace

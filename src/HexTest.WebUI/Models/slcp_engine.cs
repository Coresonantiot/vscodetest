using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HexTest.WebUI.Models{
	public class slcp_engine
	{
	[Required]
	public int Id { get; set; }

	[Required]
	public string slcp_engine_number { get; set; }		

	public string? slcp_type { get; set; }		

	public string? slcp_fuel_type { get; set; }		

}	//End of Class
}//End of Namespace

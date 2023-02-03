using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HexTest.WebUI.Models{
	public class slcp_wheel
	{
	[Required]
	public int Id { get; set; }

	[Required]
	public string slcp_type { get; set; }		

	public string? slcp_diameter { get; set; }		

	public string? slcp_heat_resistance { get; set; }		

	public int slcp_carId { get; set; }
}	//End of Class
}//End of Namespace

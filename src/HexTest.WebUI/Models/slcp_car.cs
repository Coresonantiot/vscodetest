using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HexTest.WebUI.Models{
	public class slcp_car
	{
	[Required]
	public int Id { get; set; }

	[Required]
	public string slcp_colour { get; set; }		

	public string? slcp_isshipped { get; set; }		

	public slcp_engine slcp_engine { get; set; }

		public int slcp_engineId { get; set; }

	public List<slcp_wheel> slcp_wheel { get; set; }

}	//End of Class
}//End of Namespace

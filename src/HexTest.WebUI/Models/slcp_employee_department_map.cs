using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HexTest.WebUI.Models{
	public class slcp_employee_department_map
	{
	[Required]
public int Id { get; set; }

	[Required]
public int slcp_employeeId { get; set; }

	[Required]
public int slcp_departmentId { get; set; }

		public slcp_employee slcp_employee { get; set; }

		public slcp_department slcp_department { get; set; }

}	//End of Class
}//End of Namespace

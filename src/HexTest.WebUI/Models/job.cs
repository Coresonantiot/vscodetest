using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HexTest.WebUI.Models{
	public class job
	{
	[Required]
	public int Id { get; set; }

	[Required]
	public string jname { get; set; }		

	[Required]
	public string description { get; set; }		

	[Required]
	public string processid { get; set; }		

	[Required]
	public string process_name { get; set; }		

	public string? timezone { get; set; }		

	public string? schedule_type { get; set; }		

	public DateTime? startdatetime { get; set; }		

	[Required]
	public string recureevery { get; set; }		

	[Required]
	public string recureweek { get; set; }		

	public string? notifyevent_success { get; set; }		

	public string? notifyevent_failure { get; set; }		

	public string? notify_output { get; set; }		

	public string? process_input { get; set; }		

}	//End of Class
}//End of Namespace

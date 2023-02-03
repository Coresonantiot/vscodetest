using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using HexTest.SharedKernel;
using HexTest.SharedKernel.Interfaces;
using HexTest.Core.jobAggregate.Events;
//ReferenceFiles

namespace HexTest.Core.jobAggregate;

public class job : BaseEntity
{
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

}//End of Class

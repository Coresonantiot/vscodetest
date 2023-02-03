using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using HexTest.Core.ProcessAggregate;

namespace HexTest.Application.Workflows.Arguments
{	
	public class ProcessArgs
	{
		public string EntryEvent { get; set; }
		public string ProcessName { get; set; }
		public string Invoker { get; set; } = "Web";
	}
}
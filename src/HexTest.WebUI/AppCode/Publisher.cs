using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HexTest.WebUI.Workflows
{
	public class EventArguments : EventArgs
	{
		public object Message { get; set; }

		public EventArguments(object Message)
		{
			this.Message = Message;
		}

	}
	public class Publisher
	{
		public event EventHandler<EventArguments> myEvent;

		public void Notify(object Message)
		{
			EventArguments args = new EventArguments(Message);

			if (myEvent != null)
			{
				myEvent(this, args);
			}
		}
	}
}
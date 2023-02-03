
namespace HexTest.Application.Workflows.Arguments
{
	public class EventArguments : EventArgs
	{
		public object Message { get; set; }

		public EventArguments(object Message)
		{
			this.Message = Message;
		}

	}	
}
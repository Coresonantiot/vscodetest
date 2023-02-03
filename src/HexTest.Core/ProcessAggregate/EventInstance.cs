using System;
using System.Collections.Generic;
using HexTest.SharedKernel;

namespace HexTest.Core.ProcessAggregate
{
    public partial class EventInstance : BaseEntity
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int ProcessID { get; set; }
        public string ProcessInstanceId { get; set; }        
        public int TaskID { get; set; }
        public string TaskInstanceId { get; set; }
        
    }
}

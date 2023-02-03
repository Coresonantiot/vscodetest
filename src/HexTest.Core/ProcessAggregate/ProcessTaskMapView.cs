using System;
using System.Collections.Generic;
using HexTest.Core.ProcessAggregate;
using HexTest.SharedKernel;

namespace HexTest.Core.ProcessAggregate
{
    public partial class ProcessTaskMapView : BaseEntity
    {   
        public int ProcessId { get; set; }
        public string ProcessName { get; set; } = null!;
        public int TaskId { get; set; }
        public string TaskName { get; set; } = null!;
        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public string? InputData { get; set; }
    }
}

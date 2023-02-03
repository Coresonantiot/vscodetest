using System;
using System.Collections.Generic;
using HexTest.SharedKernel;

namespace HexTest.Core.ProcessAggregate
{
    public partial class EventMaster : BaseEntity
    {   
        public string Name { get; set; } = null!;
        public string Version { get; set; } = null!;
        /// <summary>
        /// -1=Deleted, 0-Disabled, 1-Active
        /// </summary>
        public int? Status { get; set; }
        public string? EventType { get; set; }
        public string? Description { get; set; }
    }
}

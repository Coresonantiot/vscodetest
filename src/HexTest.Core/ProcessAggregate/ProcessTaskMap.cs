using System;
using System.Collections.Generic;
using HexTest.SharedKernel;


namespace HexTest.Core.ProcessAggregate
{
    public partial class ProcessTaskMap : BaseEntity
    {   
        public int ProcessId { get; set; }
        public int TaskId { get; set; }
        public int? Precedence { get; set; }
        /// <summary>
        /// -1=Deleted, 0-Disabled, 1-Active
        /// </summary>
        public int? Status { get; set; }
    }
}

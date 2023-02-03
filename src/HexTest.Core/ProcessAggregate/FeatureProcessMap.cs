using System;
using System.Collections.Generic;
using HexTest.SharedKernel;

namespace HexTest.Core.ProcessAggregate
{
    public partial class FeatureProcessMap : BaseEntity
    {
        public int Triggerid { get; set; }
        public string Triggername { get; set; } = null!;
        /// <summary>
        /// Process Master Relationship
        /// </summary>
        public int Processid { get; set; }
        public string Processname { get; set; } = null!;
        /// <summary>
        /// -1=Deleted, 0-Disabled, 1-Active
        /// </summary>
        public int? Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using HexTest.SharedKernel;

namespace HexTest.Core.ProcessAggregate
{
    public partial class TaskMaster : BaseEntity
    {   
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        /// <summary>
        /// Event Master Relationship
        /// </summary>
        public int? InputEvent { get; set; }
        /// <summary>
        /// Entity Relationship
        /// </summary>
        public int? InputData { get; set; }
        /// <summary>
        /// Event Master Relationship
        /// </summary>
        public int? SuccessOutputEvent { get; set; }
        /// <summary>
        /// Entity Relationship
        /// </summary>
        public int? SuccessOutputData { get; set; }
        /// <summary>
        /// Event Master Relationship
        /// </summary>
        public int? FailureOutputEvent { get; set; }
        /// <summary>
        /// Entity Relationship
        /// </summary>
        public int? FailureOutputData { get; set; }
        public string? TaskType { get; set; }
        /// <summary>
        /// -1=Deleted, 0-Disabled, 1-Active
        /// </summary>
        public int? Status { get; set; }
    }
}

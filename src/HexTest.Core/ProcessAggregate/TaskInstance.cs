using System;
using System.Collections.Generic;
using HexTest.SharedKernel;

namespace HexTest.Core.ProcessAggregate
{
    public partial class TaskInstance : BaseEntity
    {   
        public int TaskID { get; set; }
        public string TaskInstanceId { get; set; }        
        public int ProcessID {  get; set; } 
        public string ProcessInstanceId { get; set; }        
        public DateTime StartDateTime { get; set; } = DateTime.Now;
        public DateTime EndDateTime { get; set; }
        public string InputEvent { get; set; }
        public string OutputEvent { get; set; }
        public string InputData { get; set; } = "";
        public string OutputData { get; set; } = "";
        public TaskStatus Status { get; set; } = TaskStatus.New;
        public string Exception { get; set; } = "";
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HexTest.SharedKernel;

namespace HexTest.Core.ProcessAggregate
{
    public partial class ProcessInstance : BaseEntity
    {
        [Required]
        public int ProcessID { get; set; }        
        [Required]
        public string ProcessInstanceID { get; set; }
        [Required]
        public string Invoker { get; set; } = "Web";
        [Required]
        public string EntryEvent { get; set; }
        public DateTime StartDateTime { get; set; } = DateTime.Now;
        public DateTime EndDateTime { get; set; } 
        public  string InputData { get; set; } = "";
        public string OutputData { get; set; } = "";
        public ProcessStatus Status { get; set; } = ProcessStatus.New;
        public string Exception { get; set; } = "";
    }
}

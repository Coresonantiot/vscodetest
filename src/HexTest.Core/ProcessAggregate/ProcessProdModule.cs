using System;
using System.Collections.Generic;
using HexTest.SharedKernel;

namespace HexTest.Core.ProcessAggregate
{
    public partial class ProcessProdModule : BaseEntity
    {
        public int Mid { get; set; }
        public string Mname { get; set; } = null!;
        public string Mcode { get; set; } = null!;
        public string DbMname { get; set; } = null!;
        /// <summary>
        /// 0-Disabled, 1-Enabled
        /// </summary>
        public int Status { get; set; }
    }
}

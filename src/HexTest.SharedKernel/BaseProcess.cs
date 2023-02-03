using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexTest.SharedKernel
{
    public abstract class BaseProcess : IProcess
    {
        public string InstanceName { get; set; } 
        public string InstanceID { get; set; }

        public BaseProcess()
        {
            InstanceID = Guid.NewGuid().ToString();
        }
    }
}

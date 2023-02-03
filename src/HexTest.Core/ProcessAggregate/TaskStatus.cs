using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexTest.Core.ProcessAggregate
{
    public enum TaskStatus
    {
        New = 1,
        Completed = 0,
        InProgress = 2,
        Aborted = -1
    }
}

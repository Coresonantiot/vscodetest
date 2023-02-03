using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexTest.Application.Actions
{
    public interface IDummyAction
    {
        public Tuple<object, string> Execute();
    }
}

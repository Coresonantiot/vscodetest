using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexTest.Application;

namespace HexTest.Application.Actions
{
    public class DummyAction : IDummyAction
    {
        public Tuple<object, string> Execute()
        {
            return new Tuple<object, string>(null, null);
        }
    }
}

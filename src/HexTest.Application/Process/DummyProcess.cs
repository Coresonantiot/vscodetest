using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexTest.Application.Workflows.Arguments;



namespace HexTest.Application.Workflows
{
    public class DummyProcess : Process
    {   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="processArgs"></param>
        public DummyProcess(ProcessArgs processArgs) : base (processArgs) 
        {
            
        }
    }
}

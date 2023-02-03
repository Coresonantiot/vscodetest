using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HexTest.WebUI.Workflows.Arguments
{
    public class ProcessOutputArgs
    {
        public int ExitCode { get; internal set; }
        public Exception Exception { get; internal set; }
        public string ProcessOutput { get; internal set; }
    }
}
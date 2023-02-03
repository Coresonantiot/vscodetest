using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HexTest.WebUI.ServiceResponse
{
    public class ServiceResponse
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
    }
}
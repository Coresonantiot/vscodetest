using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexTest.Application.Interfaces;

namespace HexTest.Application
{
    public static class Common
    {
        public static IUnitOfWork UnitOfWork { get; set; }        
    }
}

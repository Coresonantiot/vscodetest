using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HexTest.SharedKernel.Interfaces;
using HexTest.Core;
using System.Reflection;

namespace CoreUI_Free_Bootstrap_Admin.Pages.Shared
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class SideBarModel : PageModel
    {
        public void OnGet()
        {

            //AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GetName() == Assembly.GetExecutingAssembly().GetName());

            var types = Assembly.Load("HexTest.Core").GetTypes().Where(m => m.IsClass && m.GetInterface("IProcess") != null);

            foreach (var type in types)
            {
                if (type.IsClass)
                {
                    Console.WriteLine(type.Name);
                }
            }
        }
    }
}

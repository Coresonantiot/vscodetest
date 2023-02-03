using Microsoft.AspNetCore.Mvc;
using HexTest.Application.Workflows.Arguments;
using HexTest.Application.Workflows;

namespace HexTest.Api.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {   
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}

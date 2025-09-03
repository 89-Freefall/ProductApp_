
using Microsoft.AspNetCore.Mvc;

namespace ProductApp.Features.HelloWorld;

[Route("hello")] // base route for this controller
public class HelloWorldController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("~/Features/HelloWorld/Views/Index.cshtml");
    }

    [HttpGet("welcome/{name?}/{numTimes?}")]
    public IActionResult Welcome(string name = "Guest", int numTimes = 1)
    {
        ViewData["Message"] = $"Hello {name}";
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}
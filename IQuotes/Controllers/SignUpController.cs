using Microsoft.AspNetCore.Mvc;

namespace IQuotes.Controllers;

public class SignUpController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Done()
    {
        return View();
    }
}
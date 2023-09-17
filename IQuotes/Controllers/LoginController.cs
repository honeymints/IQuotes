using Microsoft.AspNetCore.Mvc;

namespace IQuotes.Controllers;

public class Login : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
using IQuotes.Data;
using IQuotes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace IQuotes.Controllers;

public class QuotesController : Controller
{
    private ApplicationDbContext _db;
    public QuotesController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
       
       IEnumerable<Quotes> _listOfQuotes = _db.Quotes;
       return View(_listOfQuotes);
    }
    //GET
    public IActionResult Create()
    {
        return View();
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Quotes quotes)
    {
        quotes.Username = "aruchanism@mail.com";
        quotes.QuoteText.ToString();
        
        _db.Quotes.Add(quotes);
        
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
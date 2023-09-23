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
        
        quotes.User = new User();
        quotes.User.Email = "aruzhan@mail.ru";
        quotes.User.Username = " ";
        //quotes.QuoteText.ToString();
        quotes.User.Password = "1234567";
        quotes.UserID = 2;
        
        /*quotes.User.Quotes = new List<Quotes>();
        quotes.User.Quotes.Add(quotes);*/
        
        
        _db.Quotes.Add(quotes);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
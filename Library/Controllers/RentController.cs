using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class RentController : Controller
{
    private readonly RentManager _rentManager;
    private readonly ClientManager _clientManager;
    private readonly BookManager _bookManager;

    public RentController(
        RentManager rentManager,
        ClientManager clientManager,
        BookManager bookManager
    )
    {
        _rentManager = rentManager;
        _clientManager = clientManager;
        _bookManager = bookManager;
    }
    public IActionResult Index()
    {
        var rents = _rentManager.GetRents();
        return View(rents);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Clients = _clientManager.GetClients();
        ViewBag.Books = _bookManager.GetAvailableBooks();
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(RentModel rent)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Clients = _clientManager.GetClients();
            ViewBag.Books = _bookManager.GetAvailableBooks();
            return View(rent);
        }
        
        try
        {
            _rentManager.AddRent(rent);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            ViewBag.Clients = _clientManager.GetClients();
            ViewBag.Books = _bookManager.GetBooks();
            return View(rent);
        }
    }

    [HttpGet]
    public IActionResult Close(int id)
    {
        _rentManager.CloseRent(id);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Remove(int id)
    {
        _rentManager.RemoveRent(id);

        return RedirectToAction("Index");
    }
}
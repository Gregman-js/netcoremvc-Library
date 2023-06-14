using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class BookController : Controller
{
    private BookManager _bookManager;

    public BookController(BookManager bookManager)
    {
        _bookManager = bookManager;
    }
    public IActionResult Index()
    {
        var books = _bookManager.GetBooksWithCurrentClient();
        return View(books);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(BookModel book)
    {
        if (!ModelState.IsValid)
        {
            return View(book);
        }

        try
        {
            _bookManager.AddBook(book);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return View(book);
        }
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var book = _bookManager.GetBook(id);
        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(BookModel book)
    {
        if (!ModelState.IsValid)
        {
            return View(book);
        }

        _bookManager.UpdateBook(book);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Remove(int id)
    {
        _bookManager.RemoveBook(id);

        return RedirectToAction("Index");

    }
}

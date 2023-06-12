using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class ClientController : Controller
{
    private ClientManager _clientManager;

    public ClientController(ClientManager clientManager)
    {
        _clientManager = clientManager;
    }
    public IActionResult Index()
    {
        var clients = _clientManager.GetClients();
        return View(clients);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(ClientModel client)
    {
        if (!ModelState.IsValid)
        {
            return View(client);
        }

        try
        {
            _clientManager.AddClient(client);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return View(client);
        }
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var client = _clientManager.GetClient(id);
        return View(client);
    }

    [HttpPost]
    public IActionResult Edit(ClientModel client)
    {
        if (!ModelState.IsValid)
        {
            return View(client);
        }

        _clientManager.UpdateClient(client);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Remove(int id)
    {
        _clientManager.RemoveClient(id);

        return RedirectToAction("Index");

    }
}

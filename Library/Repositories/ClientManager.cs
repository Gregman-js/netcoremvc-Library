using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories;

public class ClientManager
{
    private readonly ApplicationDbContext _context;

    public ClientManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public ClientManager AddClient(ClientModel clientModel)
    {
        try
        {
            _context.Clients.Add(clientModel);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            clientModel.ID = 0;
            _context.Clients.Add(clientModel);
            _context.SaveChanges();
        }

        return this;
    }

    public ClientManager RemoveClient(int id)
    {
        var clientToDelete = _context.Clients.SingleOrDefault(client => client.ID == id);
        if (clientToDelete == null) return this;

        _context.Clients.Remove(clientToDelete);
        _context.SaveChanges();

        return this;
    }

    public ClientManager UpdateClient(ClientModel clientModel)
    {
        _context.Update(clientModel);
        _context.SaveChanges();
        return this;
    }

    public ClientModel GetClient(int id)
    {
        var client = _context.Clients.SingleOrDefault(c => c.ID == id);
        return client;
    }

    public List<ClientModel> GetClients()
    {
        var clients = _context.Clients.ToList();
        return clients;
    }

    public List<ClientModel> GetClientsWithRentedBooks()
    {
        var clients = _context.Clients
            .Include(c => c.Rents)
            .ThenInclude(r => r.Book)
            .ToList();
        return clients;
    }
}
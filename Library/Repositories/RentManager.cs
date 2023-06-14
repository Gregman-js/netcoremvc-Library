using Library.Data;
using Library.Enum;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories;

public class RentManager
{
    private readonly ApplicationDbContext _context;

    public RentManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public RentManager AddRent(RentModel rentModel)
    {
        rentModel.RentDate = DateTime.Now;
        rentModel.Status = RentStatusEnum.Open;
        _context.Rents.Add(rentModel);
        _context.SaveChanges();

        return this;
    }

    public RentManager RemoveRent(int id)
    {
        var rentToDelete = _context.Rents.SingleOrDefault(rent => rent.ID == id);
        if (rentToDelete == null) return this;

        _context.Rents.Remove(rentToDelete);
        _context.SaveChanges();

        return this;
    }

    public RentManager CloseRent(int id)
    {
        var rentToClose = _context.Rents.SingleOrDefault(rent => rent.ID == id);
        if (rentToClose == null) return this;

        rentToClose.Status = RentStatusEnum.Closed;

        _context.Update(rentToClose);
        _context.SaveChanges();
        return this;
    }

    public RentModel GetRent(int id)
    {
        var rent = _context.Rents.SingleOrDefault(r => r.ID == id);
        return rent;
    }

    public List<RentModel> GetRents()
    {
        var rents = _context.Rents
            .Include(r => r.Book)
            .Include(r => r.Client)
            .ToList();
        return rents;
    }
}
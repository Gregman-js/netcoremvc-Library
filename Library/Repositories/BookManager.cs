using Library.Data;
using Library.Enum;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories;

public class BookManager
{
    private readonly ApplicationDbContext _context;

    public BookManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public BookManager AddBook(BookModel bookModel)
    {
        try
        {
            _context.Books.Add(bookModel);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            bookModel.ID = 0;
            _context.Books.Add(bookModel);
            _context.SaveChanges();
        }

        return this;
    }

    public BookManager RemoveBook(int id)
    {
        var bookToDelete = _context.Books.SingleOrDefault(book => book.ID == id);
        if (bookToDelete == null) return this;

        _context.Books.Remove(bookToDelete);
        _context.SaveChanges();

        return this;
    }

    public BookManager UpdateBook(BookModel bookModel)
    {
        _context.Update(bookModel);
        _context.SaveChanges();
        return this;
    }

    public BookModel? GetBook(int id)
    {
        var book = _context.Books.SingleOrDefault(b => b.ID == id);
        return book;
    }

    public BookModel? GetBookWithClients(int id)
    {
        var book = _context.Books.Include(b => b.Rents).ThenInclude(r => r.Client).SingleOrDefault(b => b.ID == id);
        return book;
    }

    public List<BookModel> GetBooks()
    {
        var books = _context.Books.ToList();
        return books;
    }

    public List<BookModel> GetAvailableBooks()
    {
        var books = _context.Books
            .Include(b => b.Rents)
            .Where(b => b.Rents.All(r => r.Status == RentStatusEnum.Closed))
            .ToList();
        return books;
    }

    public List<BookModel> GetBooksWithCurrentClient()
    {
        var books = _context.Books
            .Include(b => b.Rents)
            .ThenInclude(r => r.Client)
            .ToList();
        return books;
    }
}
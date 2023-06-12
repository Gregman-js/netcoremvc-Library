﻿using Library.Data;
using Library.Models;

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

    public BookModel GetBook(int id)
    {
        var book = _context.Books.SingleOrDefault(film => film.ID == id);
        return book;
    }

    public List<BookModel> GetBooks()
    {
        var books = _context.Books.ToList();
        return books;
    }
}
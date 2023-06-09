﻿using Application.Abstaction;
using Application.Interface;
using Domain.Models;

namespace Application.Services;

public class BookService : IBookService
{
    private IAplicationDbContext _db;

    public BookService(IAplicationDbContext db)
    {
        _db = db;
    }
    public async Task<bool> AddAsync(Book entity)
    {
        try
        {
        await _db.Books.AddAsync(entity);
        await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public async Task<bool> AddRangeAsync(IEnumerable<Book> entities)
    {
        try
        {
            await _db.Books.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            Book? entity = await _db.Books.FindAsync(id);
            _db.Books.Remove(entity!);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }

    public IEnumerable<Book> GetAll()
    {
        try
        {
            IEnumerable<Book> entities=_db.Books;
            return entities;
        }
        catch (Exception)
        {

            return null!;
        }
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        try
        {
            Book? book = await _db.Books.FindAsync(id);
            return book!;
        }
        catch (Exception)
        {

            return null!;
        }
      
    }

    public async Task<bool> UpdateAsync(Book entity)
    {
        try
        {
            _db.Books.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
       
    }

}
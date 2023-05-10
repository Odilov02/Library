using Application.Abstaction;
using Application.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private IAplicationDbContext _db;

        public BookService(IAplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddAsync(Book entity)
        {
            await _db.Books.AddAsync(entity);
            return true;
        }

        public async Task<bool> AddRangeAsync(IQueryable<Book> entity)
        {
            await _db.Books.AddRangeAsync(entity);
            return true;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
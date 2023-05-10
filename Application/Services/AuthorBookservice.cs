using Application.Abstaction;
using Application.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthorBookService : IAuthorBookService
    {
        private readonly IAplicationDbContext _db;

        public AuthorBookService(IAplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddAsync(AuthorBook entity)
        {
            await _db.AuthorBooks.AddAsync(entity);
            return true;
        }

        public async Task<bool> AddRangeAsync(IQueryable<AuthorBook> entity)
        {
            await _db.AuthorBooks.AddRangeAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            AuthorBook? entity = await _db.AuthorBooks.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;
            _db.AuthorBooks.Remove(entity!);
            return true;
        }

        public IQueryable<AuthorBook> GetAll()
        {
            IQueryable<AuthorBook> authorBooks = _db.AuthorBooks;
            return authorBooks;
        }

        public async Task<AuthorBook> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(AuthorBook entity)
        {
            throw new NotImplementedException();
        }
    }
}
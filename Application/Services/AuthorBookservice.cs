﻿using Application.Abstaction;
using Application.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                await _db.AuthorBooks.AddAsync(entity);
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<AuthorBook> entities)
        {
            try
            {
                await _db.AuthorBooks.AddRangeAsync(entities);
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
                AuthorBook? entity = await _db.AuthorBooks.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null) return false;
                _db.AuthorBooks.Remove(entity!);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<AuthorBook> GetAll()
        {
            try
            {
                IQueryable<AuthorBook> authorBooks = _db.AuthorBooks;
                return authorBooks;

            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<AuthorBook> GetByIdAsync(int id)
        {
            try
            {
                AuthorBook? result = await _db.AuthorBooks.FirstOrDefaultAsync(x => x.Equals(id));
                return result!;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<bool> UpdateAsync(AuthorBook entity)
        {
            try
            {
                _db.AuthorBooks.Update(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
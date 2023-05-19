using Application.Abstaction;
using Application.Interface;
using Domain.Models;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAplicationDbContext _db;

        public AuthorService(IAplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddAsync(Author entity)
        {
            try
            {
                _db.Authors.Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<Author> entities)
        {
            try
            {
                _db.Authors.AddRange(entities);
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
                Author? entity = await _db.Authors.FindAsync(id);
                _db.Authors.Remove(entity!);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Author> GetAll()
        {
            try
            {
                IEnumerable<Author> entities = _db.Authors;
                return entities;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            try
            {
                Author? result = await _db.Authors.FindAsync(id);
                return result!;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<bool> UpdateAsync(Author entity)
        {
            try
            {
                _db.Authors.Update(entity);
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


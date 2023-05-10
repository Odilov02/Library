using Application.Abstaction;
using Application.Interface;
using Domain.Models;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private IAplicationDbContext _db;

        public CategoryService(IAplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddAsync(Category entity)
        {
            await _db.Category.AddAsync(entity);
            return true;
        }

        public async Task<bool> AddRangeAsync(IQueryable<Category> entity)
        {
            await _db.Category.AddRangeAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Category? entity = await _db.Category.FindAsync(id);
            _db.Category.Remove(entity!);
            return true;
        }

        public IQueryable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            Category entity
        }

        public Task<bool> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}

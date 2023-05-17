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
            await _db.Categories.AddAsync(entity);
            return true;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<Category> entities)
        {
            await _db.Categories.AddRangeAsync(entities);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            Category? entity = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(entity!);
            return true;
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}

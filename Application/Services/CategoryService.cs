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
            try
            {
            await _db.Categories.AddAsync(entity);
            await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<Category> entities)
        {
            try
            {
                await _db.Categories.AddRangeAsync(entities);
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
                Category? entity = await _db.Categories.FindAsync(id);
                _db.Categories.Remove(entity!);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<Category> GetAll()
        {
            try
            {
                IEnumerable<Category> entities = _db.Categories;
                return entities;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            try
            {
                Category? category = await _db.Categories.FindAsync(id);
                return category!;
            }
            catch (Exception)
            {

                return null!;
            }

        }

         public async Task<bool> UpdateAsync(Category entity)
        {
            try
            {
                _db.Categories.Update(entity);
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

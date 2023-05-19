using Application.Abstaction;
using Application.Interfase;
using Domain.Models;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private IAplicationDbContext _db;

        public UserService(IAplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddAsync(Users entity)
        {
            try
            {
                await _db.Users.AddAsync(entity);
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<Users> entities)
        {
            try
            {
                await _db.Users.AddRangeAsync(entities);
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
                Users? user = await _db.Users.FindAsync(id);
                _db.Users.Remove(user!);
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Users> GetAll()
        {
            try
            {
                IEnumerable<Users> users = _db.Users;
                return users;

            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            try
            {
                Users? user = await _db.Users.FindAsync(id);
                return user!;

            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<bool> UpdateAsync(Users entity)
        {
            try
            {
                _db.Users.Update(entity);
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

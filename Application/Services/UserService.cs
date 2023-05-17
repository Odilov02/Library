using Application.Abstaction;
using Application.Interfase;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
          await _db.Users.AddAsync(entity);
            _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<Users> entities)
        {
            await _db.Users.AddRangeAsync(entities);
            return true;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}

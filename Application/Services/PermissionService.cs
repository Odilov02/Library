using Application.Interfase;
using Domain.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstaction;
using Domain.Models;

namespace Application.Services
{
    public class PermissionService : IPermissionService
    {
        private IAplicationDbContext _db;

        public PermissionService(IAplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddAsync(Permission entity)
        {
            try
            {
                await _db.Permissions.AddAsync(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<Permission> entities)
        {
            try
            {
                await _db.Permissions.AddRangeAsync(entities);
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
                Permission? entity = await _db.Permissions.FindAsync(id);
                _db.Permissions.Remove(entity!);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<Permission> GetAll()
        {
            try
            {
                IEnumerable<Permission> entities = _db.Permissions;
                return entities;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            try
            {
                Permission? permission = await _db.Permissions.FindAsync(id);
                return permission!;
            }
            catch (Exception)
            {

                return null!;
            }

        }

        public async Task<bool> UpdateAsync(Permission entity)
        {
            try
            {
                _db.Permissions.Update(entity);
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
using Application.Abstaction;
using Application.Interfase;
using Domain.Models;
using Domain.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class RoleService : IRoleService
{
    private IAplicationDbContext _db;

    public RoleService(IAplicationDbContext db)
    {
        _db = db;
    }
    public async Task<bool> AddAsync(Role entity)
    {
        try
        {
            await _db.Roles.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public async Task<bool> AddRangeAsync(IEnumerable<Role> entities)
    {
        try
        {
            await _db.Roles.AddRangeAsync(entities);
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
            Role? entity = await _db.Roles.FindAsync(id);
            _db.Roles.Remove(entity!);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }

    public IEnumerable<Role> GetAll()
    {
        try
        {
            IEnumerable<Role> entities = _db.Roles;
            return entities;
        }
        catch (Exception)
        {

            return null!;
        }
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        try
        {
            Role? role = await _db.Roles.FindAsync(id);
            return role!;
        }
        catch (Exception)
        {

            return null!;
        }

    }

    public async Task<bool> UpdateAsync(Role entity)
    {
        try
        {
            _db.Roles.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }
}

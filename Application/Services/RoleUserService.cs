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

public class RoleUserService : IRoleUserService
{
    private IAplicationDbContext _db;

    public RoleUserService(IAplicationDbContext db)
    {
        _db = db;
    }
    public async Task<bool> AddAsync(RoleUser entity)
    {
        try
        {
            await _db.RoleUsers.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public async Task<bool> AddRangeAsync(IEnumerable<RoleUser> entities)
    {
        try
        {
            await _db.RoleUsers.AddRangeAsync(entities);
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
            RoleUser? entity = await _db.RoleUsers.FindAsync(id);
            _db.RoleUsers.Remove(entity!);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }

    public IEnumerable<RoleUser> GetAll()
    {
        try
        {
            IEnumerable<RoleUser> entities = _db.RoleUsers;
            return entities;
        }
        catch (Exception)
        {

            return null!;
        }
    }

    public async Task<RoleUser> GetByIdAsync(int id)
    {
        try
        {
            RoleUser? roleUser = await _db.RoleUsers.FindAsync(id);
            return roleUser!;
        }
        catch (Exception)
        {

            return null!;
        }

    }

    public async Task<bool> UpdateAsync(RoleUser entity)
    {
        try
        {
            _db.RoleUsers.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }
}

using Application.Abstaction;
using Application.Interfase;
using Domain.Models.Roles;

namespace Application.Services;

public class RolePermissionService : IRolePermissionService
{
    private IAplicationDbContext _db;

    public RolePermissionService(IAplicationDbContext db)
    {
        _db = db;
    }
    public async Task<bool> AddAsync(RolePermission entity)
    {
        try
        {
            await _db.RolePermissions.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public async Task<bool> AddRangeAsync(IEnumerable<RolePermission> entities)
    {
        try
        {
            await _db.RolePermissions.AddRangeAsync(entities);
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
            RolePermission? entity = await _db.RolePermissions.FindAsync(id);
            _db.RolePermissions.Remove(entity!);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }

    public IEnumerable<RolePermission> GetAll()
    {
        try
        {
            IEnumerable<RolePermission> entities = _db.RolePermissions;
            return entities;
        }
        catch (Exception)
        {

            return null!;
        }
    }

    public async Task<RolePermission> GetByIdAsync(int id)
    {
        try
        {
            RolePermission? rolePermission = await _db.RolePermissions.FindAsync(id);
            return rolePermission!;
        }
        catch (Exception)
        {

            return null!;
        }

    }

    public async Task<bool> UpdateAsync(RolePermission entity)
    {
        try
        {
            _db.RolePermissions.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }
}
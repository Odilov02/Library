using Application.Interface;
using Application.Interfase;
using Domain.Models;
using Domain.Models.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolePermissionController : ControllerBase
{
    private readonly IRolePermissionService _rolePermissionService;

    public RolePermissionController(IRolePermissionService rolePermissionService)
    {
        _rolePermissionService = rolePermissionService;
    }
    [HttpPost]
    [Route("Add")]
    [Authorize(Roles = "AddRolePermission")]
    public async Task<IActionResult> Add([FromBody] RolePermission entity)
    {
        bool result = await _rolePermissionService.AddAsync(entity);
        if (result)
            return Ok();
        return BadRequest();

    }
    [HttpPost]
    [Route("AddRange")]
    [Authorize(Roles = "AddRolePermission")]
    public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<RolePermission> entities)
    {
        bool result = await _rolePermissionService.AddRangeAsync(entities);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpGet]
    [Route("GetAll")]
    [Authorize(Roles = "GetRolePermission")]
    public IActionResult GetAll()
    {
        IEnumerable<RolePermission> rolePermissions = _rolePermissionService.GetAll();
        return Ok(rolePermissions);
    }
    [HttpGet]
    [Route("GetById")]
    [Authorize(Roles = "GetRolePermission")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        RolePermission rolePermission = await _rolePermissionService.GetByIdAsync(id);
        return Ok(rolePermission);
    }
    [HttpPut]
    [Route("Update")]
    [Authorize(Roles = "UpdaterolePermission")]
    public async Task<IActionResult> UpdateAsync([FromBody] RolePermission entity)
    {
        bool result = await _rolePermissionService.UpdateAsync(entity);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpDelete]
    [Route("Delete")]
    [Authorize(Roles = "DeleterolePermission")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool result = await _rolePermissionService.DeleteAsync(id);
        if (result)
            return Ok();
        return BadRequest();
    }
}



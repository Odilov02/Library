using Application.Interface;
using Application.Interfase;
using Domain.Models;
using Domain.Models.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace Library.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }
    [HttpPost]
    [Route("Add")]
    [Authorize(Roles = "AddPermission")]
    public async Task<IActionResult> Add([FromBody] Permission entity)
    {
        bool result = await _permissionService.AddAsync(entity);
        if (result)
            return Ok();
        return BadRequest();

    }
    [HttpPost]
    [Route("AddRange")]
    [Authorize(Roles = "AddPermission")]
    public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<Permission> entities)
    {
        bool result = await _permissionService.AddRangeAsync(entities);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpGet]
    [Route("GetAll")]
    [Authorize(Roles = "GetPermission")]
    public IActionResult GetAll()
    {
        IEnumerable<Permission> permissions = _permissionService.GetAll();
        return Ok(permissions);
    }
    [HttpGet]
    [Route("GetById")]
    [Authorize(Roles = "GetPermission")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Permission permission = await _permissionService.GetByIdAsync(id);
        return Ok(permission);
    }
    [HttpPut]
    [Route("Update")]
    [Authorize(Roles = "UpdatePermission")]
    public async Task<IActionResult> UpdateAsync([FromBody] Permission entity)
    {
        bool result = await _permissionService.UpdateAsync(entity);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpDelete]
    [Route("Delete")]
    [Authorize(Roles = "DeletePermission")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool result = await _permissionService.DeleteAsync(id);
        if (result)
            return Ok();
        return BadRequest();
    }
}



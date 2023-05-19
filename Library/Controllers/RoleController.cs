
using Application.Interface;
using Application.Interfase;
using Domain.Models;
using Domain.Models.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Library.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [HttpPost]
    [Route("Add")]
    [Authorize(Roles = "AddRole")]
    public async Task<IActionResult> Add([FromBody] Role entity)
    {
        bool result = await _roleService.AddAsync(entity);
        if (result)
            return Ok();
        return BadRequest();

    }
    [HttpPost]
    [Route("AddRange")]
    [Authorize(Roles = "AddRole")]
    public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<Role> entities)
    {
        bool result = await _roleService.AddRangeAsync(entities);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpGet]
    [Route("GetAll")]
    [Authorize(Roles = "GetRole")]
    public IActionResult GetAll()
    {
        IEnumerable<Role> roles = _roleService.GetAll();
        return Ok(roles);
    }
    [HttpGet]
    [Route("GetById")]
    [Authorize(Roles = "GetRole")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Role role = await _roleService.GetByIdAsync(id);
        return Ok(role);
    }
    [HttpPut]
    [Route("Update")]
    [Authorize(Roles = "UpdateRole")]
    public async Task<IActionResult> UpdateAsync([FromBody] Role entity)
    {
        bool result = await _roleService.UpdateAsync(entity);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpDelete]
    [Route("Delete")]
    [Authorize(Roles = "DeleteRole")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool result = await _roleService.DeleteAsync(id);
        if (result)
            return Ok();
        return BadRequest();
    }
}


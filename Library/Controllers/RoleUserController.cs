using Application.Interface;
using Application.Interfase;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleUserController : ControllerBase
{
    private readonly IRoleUserService _roleUserService;

    public RoleUserController(IRoleUserService roleUserService)
    {
        _roleUserService = roleUserService;
    }
    [HttpPost]
    [Route("Add")]
    [Authorize(Roles = "AddRoleUser")]
    public async Task<IActionResult> Add([FromBody] RoleUser entity)
    {
        bool result = await _roleUserService.AddAsync(entity);
        if (result)
            return Ok();
        return BadRequest();

    }
    [HttpPost]
    [Route("AddRange")]
    [Authorize(Roles = "AddRoleUser")]
    public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<RoleUser> entities)
    {
        bool result = await _roleUserService.AddRangeAsync(entities);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpGet]
    [Route("GetAll")]
    [Authorize(Roles = "GetRoleUser")]
    public IActionResult GetAll()
    {
        IEnumerable<RoleUser> roleUsers = _roleUserService.GetAll();
        return Ok(roleUsers);
    }
    [HttpGet]
    [Route("GetById")]
    [Authorize(Roles = "GetRoleUser")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        RoleUser roleUser = await _roleUserService.GetByIdAsync(id);
        return Ok(roleUser);
    }
    [HttpPut]
    [Route("Update")]
    [Authorize(Roles = "UpdateRoleUser")]
    public async Task<IActionResult> UpdateAsync([FromBody] RoleUser entity)
    {
        bool result = await _roleUserService.UpdateAsync(entity);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpDelete]
    [Route("Delete")]
    [Authorize(Roles = "DeleteRoleUser")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool result = await _roleUserService.DeleteAsync(id);
        if (result)
            return Ok();
        return BadRequest();
    }
}



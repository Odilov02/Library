using Application.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmployeeController:ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    [HttpPost]
    [Route("Add")]
    [Authorize(Roles = "AddEmployye")]
    public async Task<IActionResult> Add([FromBody] Employee entity)
    {
        bool result = await _employeeService.AddAsync(entity);
        if (result)
            return Ok();
        return BadRequest();

    }
    [HttpPost]
    [Route("AddRange")]
    [Authorize(Roles = "AddEmployee")]
    public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<Employee> entities)
    {
        bool result = await _employeeService.AddRangeAsync(entities);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpGet]
    [Route("GetAll")]
    [Authorize(Roles = "GetEmployee")]
    public IActionResult GetAll()
    {
        IEnumerable<Employee> employees = _employeeService.GetAll();
        return Ok(employees);
    }
    [HttpGet]
    [Route("GetById")]
    [Authorize(Roles = "GetEmployee")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Employee employee = await _employeeService.GetByIdAsync(id);
        return Ok(employee);
    }
    [HttpPut]
    [Route("Update")]
    [Authorize(Roles = "UpdateEmployee")]
    public async Task<IActionResult> UpdateAsync([FromBody] Employee entity)
    {
        bool result = await _employeeService.UpdateAsync(entity);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpDelete]
    [Route("Delete")]
    [Authorize(Roles = "DeleteEmployee")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool result = await _employeeService.DeleteAsync(id);
        if (result)
            return Ok();
        return BadRequest();
    }

}



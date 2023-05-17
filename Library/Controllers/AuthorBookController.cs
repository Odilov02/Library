using Application.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AuthorBookController:ControllerBase
{
    private readonly IAuthorBookService _authorBookService;

    public AuthorBookController(IAuthorBookService authorBookService)
    {
        _authorBookService = authorBookService;
    }
    [HttpPost]
    [Route("Add")]
    [Authorize(Roles = "AddAuthorBook")]
    public async Task<IActionResult> Add([FromBody] AuthorBook entity)
    {
        bool result = await _authorBookService.AddAsync(entity);
        if (result)
            return Ok();
        return BadRequest();

    }
    [HttpPost]
    [Route("AddRange")]
    [Authorize(Roles = "AddAuthorBook")]
    public async Task<IActionResult> AddRangeAsync([FromBody] IQueryable<AuthorBook> entities)
    {
        bool result = await _authorBookService.AddRangeAsync(entities);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpGet]
    [Route("GetAll")]
    [Authorize(Roles = "GetAuthorBook")]
    public IActionResult GetAll()
    {
        IEnumerable<AuthorBook> books = _authorBookService.GetAll();
        return Ok(books);
    }
    [HttpGet]
    [Route("GetById")]
    [Authorize(Roles = "GetBook")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        AuthorBook book = await _authorBookService.GetByIdAsync(id);
        return Ok(book);
    }
    [HttpPut]
    [Route("Update")]
    [Authorize(Roles = "UpdateAuthorBook")]
    public async Task<IActionResult> UpdateAsync([FromBody] AuthorBook entity)
    {
        bool result = await _authorBookService.UpdateAsync(entity);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpDelete]
    [Route("Delete")]
    [Authorize(Roles = "DeleteAuthorBook")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool result = await _authorBookService.DeleteAsync(id);
        if (result)
            return Ok();
        return BadRequest();
    }
}

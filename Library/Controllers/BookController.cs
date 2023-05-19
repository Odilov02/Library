using Application.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BookController:ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService=bookService;
    }
    [HttpPost]
    [Route("Add")]
    [Authorize(Roles ="AddBook")]
    public async Task<IActionResult> Add([FromBody] Book entity)
    {
      bool result=await _bookService.AddAsync(entity);
        if (result)
            return Ok();
        return BadRequest();
        
    }
    [HttpPost]
    [Route("AddRange")]
    [Authorize(Roles = "AddBook")]
    public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<Book> entities)
    {
        bool result = await _bookService.AddRangeAsync(entities);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpGet]
    [Route("GetAll")]
    [Authorize(Roles = "GetBook")]
    public IActionResult GetAll()
    {
      IEnumerable<Book> books=_bookService.GetAll();
        return Ok(books);
    }
    [HttpGet]
    [Route("GetById")]
    [Authorize(Roles = "GetBook")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Book book = await _bookService.GetByIdAsync(id);
        return Ok(book);
    }
    [HttpPut]
    [Route("Update")]
    [Authorize(Roles = "UpdateBook")]
    public async Task<IActionResult> UpdateAsync([FromBody] Book entity)
    {
      bool result = await _bookService.UpdateAsync(entity);
        if(result)
            return Ok();
        return BadRequest();
    }
    [HttpDelete]
    [Route("Delete")]
    [Authorize(Roles = "DeleteBook")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool result = await _bookService.DeleteAsync(id);
        if (result)
            return Ok();
        return BadRequest();
    }
}

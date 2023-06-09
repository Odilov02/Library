﻿using Application.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AuthorController : ControllerBase
{

    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    [HttpPost]
    [Route("Add")]
    [Authorize(Roles = "AddAuthor")]
    public async Task<IActionResult> Add([FromBody] Author entity)
    {
        bool result = await _authorService.AddAsync(entity);
        if (result)
            return Ok();
        return BadRequest();

    }
    [HttpPost]
    [Route("AddRange")]
    [Authorize(Roles = "AddAuthor")]
    public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<Author> entities)
    {
        bool result = await _authorService.AddRangeAsync(entities);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpGet]
    [Route("GetAll")]
    [Authorize(Roles = "GetAuthor")]
    public IActionResult GetAll()
    {
        IEnumerable<Author> books = _authorService.GetAll();
        return Ok(books);
    }
    [HttpGet]
    [Route("GetById")]
    [Authorize(Roles = "GetBook")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Author book = await _authorService.GetByIdAsync(id);
        return Ok(book);
    }
    [HttpPut]
    [Route("Update")]
    [Authorize(Roles = "UpdateAuthor")]
    public async Task<IActionResult> UpdateAsync([FromBody] Author entity)
    {
        bool result = await _authorService.UpdateAsync(entity);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpDelete]
    [Route("Delete")]
    [Authorize(Roles = "DeleteAuthor")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool result = await _authorService.DeleteAsync(id);
        if (result)
            return Ok();
        return BadRequest();
    }

}

using Application.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoryController:ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpPost]
    [Route("Add")]
    [Authorize(Roles = "AddCategory")]
    public async Task<IActionResult> Add([FromBody] Category entity)
    {
        bool result = await _categoryService.AddAsync(entity);
        if (result)
            return Ok();
        return BadRequest();

    }
    [HttpPost]
    [Route("AddRange")]
    [Authorize(Roles = "AddCategory")]
    public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<Category> entities)
    {
        bool result = await _categoryService.AddRangeAsync(entities);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpGet]
    [Route("GetAll")]
    [Authorize(Roles = "GetCategory")]
    public IActionResult GetAll()
    {
        IEnumerable<Category> categories = _categoryService.GetAll();
        return Ok(categories);
    }
    [HttpGet]
    [Route("GetById")]
    [Authorize(Roles = "GetCategory")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Category category = await _categoryService.GetByIdAsync(id);
        return Ok(category);
    }
    [HttpPut]
    [Route("Update")]
    [Authorize(Roles = "UpdateCategory")]
    public async Task<IActionResult> UpdateAsync([FromBody] Category entity)
    {
        bool result = await _categoryService.UpdateAsync(entity);
        if (result)
            return Ok();
        return BadRequest();
    }
    [HttpDelete]
    [Route("Delete")]
    [Authorize(Roles = "DeleteCategory")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool result = await _categoryService.DeleteAsync(id);
        if (result)
            return Ok();
        return BadRequest();
    }

}


using Application.UseCases.Categories.Commands;
using Application.UseCases.Categories.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(string categoryName)
    {
        var createdId= await _mediator.Send(new CreateCategoryCommand { CategoryName = categoryName });
        return Ok(createdId);    
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _mediator.Send(new GetAllCategoryQuery());
        return Ok(categories);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
        return Ok(category);    
    }


    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateCategoryCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCategoryCommand { Id = id });
        return NoContent();
    }
}

using Application.UseCases.Categories.Commands.Create;
using Application.UseCases.Categories.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCategory(string categoryName)
    {
       var created= await _mediator.Send(new CreateCategoryCommand { CategoryName = categoryName });
        return Ok(created);    
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllCategory()
    {
        var categories = await _mediator.Send(new GetAllCategoryQuery());
        return Ok(categories);
    }


}

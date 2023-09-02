using Application.Common.Interfaces;
using Application.UseCases.Products.Commands;
using Application.UseCases.Products.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : BaseController
{

    [HttpGet("[action]")]
    public async Task<IActionResult> GetPaginated(int page, int limit, string orderby = null)
    {
        return Ok(await _mediator.Send(new GetProductsPaginationQuery() { Page = page, Limit = limit, OrderByColumn= orderby}));
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllProductQuery()));
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetProductByIdQuery { Id = id }));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProductCommand { Id = id });
        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateProductCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }


    

}

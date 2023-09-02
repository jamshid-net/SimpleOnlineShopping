using Application.Common.Interfaces;
using Application.UseCases.Products.Commands;
using Application.UseCases.Products.Queries;
using Bogus;
using Domain.Entities;
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


    [HttpGet("generate")]
    public async Task<IActionResult> Generate()
    {
        Faker faker = new Faker();
        for (int i = 0; i < 50; i++)
        {
            Product product = new();
            product.CategoryId = 1;
            product.ProductName = faker.Commerce.ProductName();
            product.ProductPicture = faker.Image.LoremFlickrUrl();
            product.ProductPrice = float.Parse(faker.Commerce.Price());
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

        }
        return Ok(true);
    }
    

}

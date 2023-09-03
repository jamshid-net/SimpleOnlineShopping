using Application.UseCases.Orders.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand command)
    {
       return Ok(await _mediator.Send(command));
    }
}

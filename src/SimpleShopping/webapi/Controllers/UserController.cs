using Application.UseCases.Users.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator _mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
}

using Application.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace webapi.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {

            await _next(httpContext);
        }

        catch (NotFoundException ex)
        {

            await HandleException(httpContext, ex, HttpStatusCode.NotFound, ex.Message);
        }
        catch (AlreadyExistsException ex)
        {
            await HandleException(httpContext, ex, HttpStatusCode.Conflict, ex.Message);
        }
        //catch (UnauthorizedException ex)
        //{
        //    await HandleException(httpContext, ex, HttpStatusCode.Unauthorized, ex.Message);
        //}
        //catch (ValidationException ex)
        //{
        //    await HandleException(httpContext, ex, HttpStatusCode.BadRequest, ex.Message);
        //}

        catch (Exception ex)
        {
            await HandleException(httpContext, ex, HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async ValueTask HandleException<TException>(HttpContext httpContext, TException ex, HttpStatusCode httpStatusCode, string message)
    {

        _logger.LogError("EXCEPTION:🔴 CLIENT_IP:{ClientIp}  CLIENT:{ERROR} " + $"\nDatetime:{DateTime.Now} | Message:{message} | Path:{httpContext.Request.Path}");
        //string text = $"EXCEPTION 🔴:{message}\nDATE:{DateTime.Now}\nSTATUSCODE:{httpStatusCode}\nREQUEST_PATH:{httpContext.Request.Path}\n";
        //await _botClient.SendTextMessageAsync(chatId: "-1001856623462", text: text);
        HttpResponse response = httpContext.Response;
        response.ContentType = "application/json";


        ErrorResponse<TException> error = new()
        {
            Error = message,
            StatusCode = (int)httpStatusCode,
            IsSuccess = false,
            Result = ex
        };
        var result = JsonConvert.SerializeObject(error);
        await response.WriteAsync(result);

    }
}

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionMiddleware>();
    }
}


file class ErrorResponse<T>
{
    public string Error { get; set; }
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; } = false;
    public T Result { get; set; }   
}

using System.Text.Json;
using DarnThirsty.Application.Commands.Global;
using DarnThirsty.Core.Exceptions;

namespace DarnThirsty.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        if (exception is NoContentException)
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        else if (exception is UnauthorizedAccessException)
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        else if (exception is NotFoundException)
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        else if (exception is ConflictException)
            context.Response.StatusCode = StatusCodes.Status409Conflict;
        else
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new ExceptionResponse
        {
            status_code = context.Response.StatusCode,
            message = exception.Message
        };

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}
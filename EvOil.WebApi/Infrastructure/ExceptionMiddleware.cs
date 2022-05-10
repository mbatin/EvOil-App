using System.ComponentModel.DataAnnotations;
using EvOil.Business.Exceptions;
using Microsoft.AspNetCore.Http;

namespace EvOil.WebApi.Infrastructure;

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
        catch (ValidationException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
        catch (NotFoundException)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
        catch (Exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}

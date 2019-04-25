using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;

        if (ex is ArgumentNullException) code = HttpStatusCode.NotFound;
        else if (ex is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
        else if (ex is ArgumentException) code = HttpStatusCode.BadRequest;

        _logger.LogError(ex.Message);

        var result = JsonConvert.SerializeObject(new { error = ex.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}
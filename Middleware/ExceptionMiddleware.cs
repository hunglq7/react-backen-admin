using System.Net;
using System.Text.Json;
using WebApi.Models.Common;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                ArgumentNullException
          or ArgumentException => StatusCodes.Status400BadRequest,

                KeyNotFoundException => StatusCodes.Status404NotFound,

                _ => StatusCodes.Status500InternalServerError
            };

            var response = ApiResponse<string>.Fail(ex.Message);

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response)
            );
        }
    }
}
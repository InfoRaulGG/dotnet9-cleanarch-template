using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
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
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = JsonSerializer.Serialize(new { error = ex.Message });
                await context.Response.WriteAsync(response);
            }
        }
    }
}
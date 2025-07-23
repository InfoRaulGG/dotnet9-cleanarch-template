using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Api.Middlewares
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;
        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
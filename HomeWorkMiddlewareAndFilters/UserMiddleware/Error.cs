using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HomeWorkMiddlewareAndFilters.UserMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Error
    {
        private readonly RequestDelegate _next;

        public Error(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            await _next.Invoke(httpContext);
            if (httpContext.Response.StatusCode == 403)
            {
                await httpContext.Response.WriteAsync("Access Denied");
            }
            else if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("Not Found");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorExtensions
    {
        public static IApplicationBuilder UseError(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Error>();
        }
    }
}

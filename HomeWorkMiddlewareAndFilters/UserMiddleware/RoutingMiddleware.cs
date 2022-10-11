using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeWorkMiddlewareAndFilters.UserMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RoutingMiddleware
    {
        readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path;
            if (path == "/Home/Index")
            {
                //await context.Response.WriteAsync("Home Page");
                await _next.Invoke(context);
            }
            else if (path == "/Home/AddUser")
            {
                //await context.Response.WriteAsync("About Page");
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RoutingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRoutingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoutingMiddleware>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HomeWorkMiddlewareAndFilters.UserMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var pass = httpContext.Request.Query["pass"];
            if(pass != "123")
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await _next.Invoke(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class AuthenticationMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<AuthenticationMiddleware>();
    //    }
    //}
}

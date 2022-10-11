using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkMiddlewareAndFilters.UserMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UserRequestsMiddleware
    {
        private readonly RequestDelegate _next;

        public UserRequestsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path != "/favicon.ico") { 

            string file = "UserRequests.txt";
            using (FileStream fs = new FileStream(file, FileMode.Append))
            {
                string userpath = httpContext.Request.Path;
                userpath += "\n";
                byte[] buffer = Encoding.Default.GetBytes(userpath);
                await fs.WriteAsync(buffer, 0, buffer.Length);
            }
        }
            await _next.Invoke(httpContext);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UserRequestsMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserRequestsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserRequestsMiddleware>();
        }
    }
}

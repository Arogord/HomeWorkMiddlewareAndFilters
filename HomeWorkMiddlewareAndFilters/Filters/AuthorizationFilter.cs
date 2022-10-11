using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeWorkMiddlewareAndFilters.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string path = "FilterLog.txt";
            string text = "AuthorizationFilter, method - OnAuthorization \n";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(text);
            }
        }
    }
}

using HomeWorkMiddlewareAndFilters.Filters;
using HomeWorkMiddlewareAndFilters.UserMiddleware;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add(new AuthorizationFilter());
            options.Filters.Add(new ResourceFilter());
            options.Filters.Add(new ActionFilter());
            options.Filters.Add(new ExceptionFilter());
            options.Filters.Add(new ResultFilter());
        });

        var app = builder.Build();

        app.UseError();
        app.UseUserRequestsMiddleware();// save user request
        
        //app.UseMiddleware<Error>(); //Without Extension 

        app.UseMiddleware<AuthenticationMiddleware>();
        app.UseRoutingMiddleware();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=AddUser}/{id?}");
        app.Run();
    }
}
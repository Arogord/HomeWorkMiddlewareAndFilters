using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeWorkMiddlewareAndFilters.Filters
{
    public class ResourceFilter : Attribute, IResourceFilter
    {
        void IResourceFilter.OnResourceExecuted(ResourceExecutedContext context)
        {
            string path = "FilterLog.txt";
            string text = "ResourceFilter, method - OnResourceExecuted \n";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(text);
            }
        }

        void IResourceFilter.OnResourceExecuting(ResourceExecutingContext context)
        {
            string path = "FilterLog.txt";
            string text = "ResourceFilter, method - OnResourceExecuting \n";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(text);
            }
        }
    }
}

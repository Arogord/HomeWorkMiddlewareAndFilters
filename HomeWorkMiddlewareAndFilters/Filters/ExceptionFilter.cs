using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeWorkMiddlewareAndFilters.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string path = "FilterLog.txt";
            string text = "ExceptionFilter, method - OnException \n";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(text);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeWorkMiddlewareAndFilters.Filters
{
    public class ResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            string path = "FilterLog.txt";
            string text = "ResultFilter, method - OnResultExecuted \n";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(text);
            }
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            string path = "FilterLog.txt";
            string text = "ResultFilter, method - OnResultExecuting \n";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(text);
            }
        }
    }
}

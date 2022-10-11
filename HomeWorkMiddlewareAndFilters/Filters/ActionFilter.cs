using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeWorkMiddlewareAndFilters.Filters
{
    public class ActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string path = "FilterLog.txt";
            string text = "ActionFilter, method - OnActionExecuted \n";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(text);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string path = "FilterLog.txt";
            string text = "ActionFilter, method - OnActionExecuting \n";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(text);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab11.Filters;

public class ActionLogFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        
        var route = context.RouteData.Values
            .Select(kv => kv.Value)
            .Aggregate((a, b) => a + "/" + b)
            .ToString();
        
        var file = config.GetRequiredSection("ActionLogFilterFile").Value;
        
        File.AppendAllText(file, $"{DateTime.Now} - {route}{Environment.NewLine}");
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
    }
}
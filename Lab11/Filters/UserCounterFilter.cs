using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab11.Filters;

public class UserCounterFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var file = config.GetRequiredSection("UserCounterFilterFile").Value;
        
        if (!File.Exists(file))
            File.WriteAllText(file, "0" + Environment.NewLine);
        
        var fileLines = File.ReadAllLines(file).ToList();

        var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
        if (!fileLines.Any(l => l.Contains(ip)))
        {
            fileLines.Add(ip);
            
            var userCount = Convert.ToInt32(fileLines[0]) + 1;
            fileLines[0] = userCount.ToString();
            
            File.WriteAllLines(file, fileLines);
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
    }
}
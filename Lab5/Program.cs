using Lab5;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "errors.txt"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Extensions.Html(
    @"<form method='POST'>
        <input type='text' name='value'>
        <input type='datetime-local' name='datetime'>
        <input type='submit'>
      </form>"
));

app.MapPost("/", async (HttpContext ctx) =>
{
    var value = ctx.Request.Form["value"];
    var dateTime = DateTime.Parse(ctx.Request.Form["datetime"]);

    ctx.Response.Cookies.Append("value", value, new CookieOptions { Expires = dateTime });
    
    ctx.Response.Redirect("/check");
});

app.MapGet("/check", async (ctx) =>
{
    if (ctx.Request.Cookies.ContainsKey("value"))
    {
        var cookie = ctx.Request.Cookies["value"];
        await ctx.Response.WriteAsync($"value set: '{cookie}'");
    }
    else
    {
        await ctx.Response.WriteAsync("no cookie set");
    }
});

app.MapGet("/unset", async (ctx) =>
{
    ctx.Response.Cookies.Delete("value");
    ctx.Response.Redirect("/");
});

app.Run();
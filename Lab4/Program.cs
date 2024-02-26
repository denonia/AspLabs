using Lab4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Configuration.AddJsonFile("Properties/books.json");
builder.Configuration.AddJsonFile("Properties/users.json");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Map("/Library", () => "Welcome to the library :D Visit /Books or /Profile");

app.Map("/Library/Books", (IConfiguration config) =>
{
    var books = new List<Book>();
    config.GetSection("Books").Bind(books);
    return books;
});

app.Map("/Library/Profile/{id:int:range(0,5)?}",  (IConfiguration config, int? id) =>
{
    var users = new List<User>();
    config.GetSection("Users").Bind(users);
    return users.First(u => u.Id == (id ?? 0));
});

app.Run();
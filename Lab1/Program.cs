using Lab1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var company = new Company
{
    Name = "Apple",
    FoundedAt = new DateOnly(1976, 1, 1),
    FounderName = "Steve Jobs",
    EmployeeCount = 161000
};

// app.Run(async (context) =>
// {
//     await context.Response.WriteAsJsonAsync(company);
// });

app.Run(async (context) =>
{
    await context.Response.WriteAsync(Random.Shared.Next(0, 100).ToString());
});

app.Run();
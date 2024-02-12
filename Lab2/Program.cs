using Lab2.Controllers;
using Lab2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<CompanyService>();

var app = builder.Build();

builder.Configuration.AddIniFile("Properties/companies.ini");
builder.Configuration.AddXmlFile("Properties/companies.xml");
builder.Configuration.AddJsonFile("Properties/companies.json");
builder.Configuration.AddJsonFile("Properties/aboutme.json");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Map("/", (IConfiguration appConfig) =>
{
    Console.WriteLine(appConfig.GetSection("Microsoft").GetSection("Employees").Value);
});

app.Run();
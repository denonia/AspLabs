using Lab2.Models;

namespace Lab2.Services;

public class CompanyService
{
    private readonly IConfiguration _configuration;

    public CompanyService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public Company GetCompanyWithMostEmployees()
    {
        var companies = new List<Company>
        {
            _configuration.GetSection("Microsoft").Get<Company>(),
            _configuration.GetSection("Apple").Get<Company>(),
            _configuration.GetSection("Google").Get<Company>(),
        };

        return companies.MaxBy(c => c.Employees);
    }
}
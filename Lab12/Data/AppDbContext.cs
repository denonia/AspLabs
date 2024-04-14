using Lab12.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
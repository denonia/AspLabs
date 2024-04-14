using Lab12.Data;
using Lab12.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _appDbContext;

    public UserService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public void CreateUser(User user)
    {
        _appDbContext.Users.Add(user);
        _appDbContext.SaveChanges();
    }

    public User? GetUserById(Guid id)
    {
        return _appDbContext.Users.SingleOrDefault(u => u.Id == id);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _appDbContext.Users;
    }

    public void UpdateUser(Guid id, User user)
    {
        _appDbContext.Entry(user).State = EntityState.Modified;
        _appDbContext.SaveChanges();
    }

    public void DeleteUser(Guid id)
    {
        var user = _appDbContext.Users.SingleOrDefault(u => u.Id == id);
        _appDbContext.Users.Remove(user ?? throw new InvalidOperationException());
        _appDbContext.SaveChanges();
    }
}
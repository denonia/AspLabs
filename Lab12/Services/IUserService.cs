using Lab12.Models;

namespace Lab12.Services;

public interface IUserService
{
    void CreateUser(User user);
    User? GetUserById(Guid id);
    IEnumerable<User> GetAllUsers();
    void UpdateUser(Guid id, User user);
    void DeleteUser(Guid id);
}
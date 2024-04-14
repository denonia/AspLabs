using Lab12.Models;
using Lab12.Services;

namespace Lab12.Data;

public class UserSeed
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var userService = serviceProvider.GetRequiredService<IUserService>();

        var allUsers = userService.GetAllUsers();
        if (!allUsers.Any())
        {
            userService.CreateUser(new User("John", "Doe", 99));
            userService.CreateUser(new User("Jane", "Doe", 88));
            userService.CreateUser(new User("Joe", "Biden", 81));
        }

        foreach (var user in allUsers)
        {
            Console.WriteLine($"{user.Id} {user.FirstName} {user.LastName} - {user.Age}");
        }
    }
}
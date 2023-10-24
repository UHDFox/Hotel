using Hotel.Interfaces;
using Hotel.Models;

namespace Hotel.Services;

public class UserService : IUsers
{
    private readonly DataContext _context;
    public UserService(DataContext context)
    {
        _context = context;
    }


    public List<User> ShowAllUsers()
    {
        return _context.Users.ToList();
    }

    public async Task<User> AddNewUser(NewUserRequest request)
    {
        User user = new User { 
            Login = request.Login,
            Password = request.Password,
            UserName = request.UserName,
            Email = request.Email,
        };
        var tracking = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return tracking.Entity;
    }
}
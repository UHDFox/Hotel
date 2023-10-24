using Hotel.Models;

namespace Hotel.Interfaces;

public interface IUsers
{
    public List<User> ShowAllUsers();

    public Task<User> AddNewUser(NewUserRequest request);
}

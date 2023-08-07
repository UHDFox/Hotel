using Hotel.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Hotel.Interfaces
{
    public interface IAuth
    {
        /*List<User> GetAllUsers();
        User GetUserById(int id);*/
        
        public string Login(string login, string password);

        

    }
}

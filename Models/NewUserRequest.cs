namespace Hotel.Models;

public sealed class NewUserRequest
{
    public string Login { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }
}

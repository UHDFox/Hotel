using Microsoft.AspNetCore.Mvc;
using Hotel.Interfaces;

namespace Hotel.Controllers;

[Route("api/login")]
[ApiController]
public class AuthController : Controller
{
    private readonly IAuth context;

    public AuthController(IAuth context)
    {
        this.context = context;
    }

    [HttpPost]
    public string Login(string login, string password) =>  context.Login(login,password);
}

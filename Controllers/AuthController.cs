using Microsoft.AspNetCore.Mvc;
using Hotel.Interfaces;

namespace Hotel.Controllers;

[Route("api/login")]
[ApiController]
public class AuthController : Controller
{
    private readonly IAuth _context;
        
    public AuthController(IAuth context)
    {
        _context = context;
    }

    [HttpPost]
    public string Login(string login, string password) =>  _context.Login(login,password);
}
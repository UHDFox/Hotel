using Hotel.Models;
using Hotel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : Controller
{
    public readonly IUsers _context;
    public UsersController(IUsers context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult ShowAllUsers()
    {
        List<User> users = _context.ShowAllUsers();
        return Ok(users);
    }

    [HttpPost]
    public async Task<User> AddNewUser(NewUserRequest request) => await _context.AddNewUser(request);
}
using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : Controller
{
    private readonly IUsers context;

    public UsersController(IUsers context)
    {
        this.context = context;
    }

    [HttpGet]
    public IActionResult ShowAllUsers()
    {
        var users = context.ShowAllUsers();
        return Ok(users);
    }

    [HttpPost]
    public async Task<User> AddNewUser(NewUserRequest request) => await context.AddNewUser(request);
}

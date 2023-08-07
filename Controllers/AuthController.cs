using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Hotel.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Hotel.Interfaces;
using Microsoft.AspNetCore.Identity;
using Hotel.Services;
namespace Hotel.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : Controller
    {
        /*private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }*/
        private readonly IAuth _context;
        
        public AuthController(IAuth context)
        {
            _context = context;
        }

        [HttpPost]
        public string Login(string login, string password) =>  _context.Login(login,password);
       







    }
}

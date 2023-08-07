using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.ComponentModel;
using System.Diagnostics;
using NuGet.Protocol.Plugins;
using Microsoft.IdentityModel.Tokens;

namespace Hotel.Services
{
    
    public class AuthService : IAuth
    {
        private readonly DataContext _context;
        public AuthService(DataContext context)
        {
            _context = context;
        }
        
        public string Login(string login, string password)
        {
            User? user = _context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user == null) {/* return Results.Unauthorized; */}

            var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email )};
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(3)),
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                username = user.UserName
            };
            return encodedJwt   ;
        }

       /* public async Task<IResult> AddUser (NewUserRequest request, HttpContext httpContext, string? returnUrl) 
        {
            User user1 = new User()
            {
                UserName = request.UserName,
                Email = request.Email,
                Login = request.Login,
                Password = request.Password,
            };
            User? user = _context.Users.FirstOrDefault(x => x.UserName == request.UserName && x.Password == request.Password && x.Login == request.Login && x.Email == request.Email);
            if(user == null)
            {
                return Results.Unauthorized();
            }
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };
            // создаем объект ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Results.Redirect(returnUrl ?? "/");
        }*/
    }
}

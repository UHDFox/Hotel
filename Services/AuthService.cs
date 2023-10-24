using Hotel.Interfaces;
using Hotel.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Hotel.Services;

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
}
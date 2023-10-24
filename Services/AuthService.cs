using Hotel.Interfaces;
using Hotel.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Hotel.Services;

public class AuthService : IAuth
{
    private readonly DataContext context;
    public AuthService(DataContext context)
    {
        this.context = context;
    }

    public string Login(string login, string password)
    {
        User? user = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
        if (user == null) {/* return Results.Unauthorized; */}

        var claims = new List<Claim> { new(ClaimTypes.Email, user.Email )};
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(3)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt   ;
    }
}

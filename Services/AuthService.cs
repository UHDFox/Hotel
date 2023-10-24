using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Hotel.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Hotel.Services;

internal sealed class AuthService : IAuth
{
    private readonly DataContext context;

    public AuthService(DataContext context)
    {
        this.context = context;
    }

    public string Login(string login, string password)
    {
        var user = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
        if (user == null)
        {
            /* return Results.Unauthorized; */
        }

        var claims = new List<Claim> { new(ClaimTypes.Email, user.Email) };
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(3)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
}

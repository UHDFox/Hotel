using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Hotel;

public sealed class AuthOptions
{
    public const string Issuer = "CapybaraInc";
    public const string Audience = "HotelClient";
    private const string Key = "superpassword that is long enough to make this programm run without trouble";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Key));
}

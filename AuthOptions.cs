using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hotel;

public class AuthOptions
{
    public const string Issuer = "CapybaraInc";
    public const string Audience = "HotelClient";
    private const string Key = "superpassword that is long enough to make this programm run without trouble";
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
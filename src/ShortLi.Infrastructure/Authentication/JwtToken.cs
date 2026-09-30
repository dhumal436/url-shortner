using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ShortLi.Infrastructure.Authentication;

public class JwtToken : IJWTToken
{
    public string GenrateToken(Guid userId, string firstName, string lastName)
    {
        List<Claim> claims  = new List<Claim>();
        var signingCredintials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-256-bit-key-super-secrete-1")), SecurityAlgorithms.HmacSha256);
        
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, lastName));
        claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, firstName));
         
         var token = new JwtSecurityToken(issuer:"me", expires:DateTime.Now.AddMinutes(30), claims:claims, signingCredentials:signingCredintials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
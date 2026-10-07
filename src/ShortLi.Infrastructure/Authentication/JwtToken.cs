using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ShortLi.Infrastructure.Authentication.JWT;
using Microsoft.Extensions.Options;

namespace ShortLi.Infrastructure.Authentication;

public class JwtToken : IJWTToken
{
    JwtSettings _jwtSettings;
    public JwtToken(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings=jwtSettings.Value;
    }
    public string GenrateToken(Guid userId, string firstName, string lastName)
    {
        List<Claim> claims  = new List<Claim>();
        var signingCredintials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);
        
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, lastName));
        claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, firstName));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
         
         var token = new JwtSecurityToken(issuer:_jwtSettings.Issuer,
                                            audience:_jwtSettings.Audience,
                                            expires:DateTime.Now.AddMinutes(30), 
                                            claims:claims, signingCredentials:signingCredintials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
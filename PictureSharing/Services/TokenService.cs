using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PictureSharing.Services.Interface;
using Microsoft.IdentityModel.Tokens;


namespace PictureSharing.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async ValueTask<string> GetTokenAsync(string email,string password)
    {
        string key = _configuration.GetSection("Authentication")["SecurityKey"];
        string issuer = _configuration.GetSection("Authentication")["Issuer"];
        string audience = _configuration.GetSection("Authentication")["Audience"];
        int expiresInMinutes = _configuration.GetSection("Authentication").GetValue<int>("ExpireAtInMinutes");
        
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, email),
            new Claim("password", password)
        };

        var jwtSecurityToken = new JwtSecurityToken(
            claims: claims,
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256),
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddMinutes(expiresInMinutes)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
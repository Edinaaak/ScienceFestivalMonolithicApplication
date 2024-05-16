using Microsoft.IdentityModel.Tokens;
using ScienceFestivalMonolithicApplication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ScienceFestivalMonolithicApplication.Services
{
    public class TokenService
    {

        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Token:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("userId", user.Id.ToString())
                }),
                Audience = _configuration.GetSection("Token:Audience").Value,
                Issuer = _configuration.GetSection("Token:Issuer").Value,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        public string ExtractJuryIdFromToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken != null)
            {
                var juryIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "userId");

                if (juryIdClaim != null)
                {
                    return juryIdClaim.Value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}

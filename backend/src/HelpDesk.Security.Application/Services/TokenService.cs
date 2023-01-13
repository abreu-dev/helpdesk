using HelpDesk.Security.Application.Models;
using HelpDesk.Security.Application.Services.Interfaces;
using HelpDesk.Security.Application.Settings;
using HelpDesk.Security.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HelpDesk.Security.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateAuthenticationToken(UserDomain user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Email", user.Email),
                    new Claim("Username", user.Username),
                    new Claim("Language", user.Language)
                }),
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiresInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public ValidatedToken ValidateToken(string? token)
        {
            if (string.IsNullOrEmpty(token)) return GetInvalidToken();

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                return GetValidToken(jwtToken.Claims);
            }
            catch
            {
                return GetInvalidToken();
            }
        }

        private ValidatedToken GetValidToken(IEnumerable<Claim> claims)
        {
            return new ValidatedToken()
            {
                IsValid = true,
                User = new AuthenticatedUser()
                {
                    Id = Guid.Parse(claims.First(x => x.Type == "Id").Value),
                    Name = claims.First(x => x.Type == "Name").Value,
                    Email = claims.First(x => x.Type == "Email").Value,
                    Username = claims.First(x => x.Type == "Username").Value,
                    Language = claims.First(x => x.Type == "Language").Value
                }
            };
        }

        private ValidatedToken GetInvalidToken()
        {
            return new ValidatedToken()
            {
                IsValid = false
            };
        }
    }
}

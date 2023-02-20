using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using User_API.UserApi.Domain.DTOs;

namespace User_API.UserApi.Services
{
    public interface IAuthenticationService
    {
        public string HashUserId(string userId);
        public string GenerateJWToken(string userId);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJWToken(string userId)
        {
            var key = _configuration["Security:JWT:Key"];
            var expiry = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Security:JWT:Expiry"]));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims =  new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds.ToString(), ClaimValueTypes.Integer)
            };


            var token = new JwtSecurityToken(_configuration["Security:JWT:Issuer"],
                null,
                claims,
                expires: expiry,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string HashUserId(string userId)
        {
            var salt = _configuration["Security:Salt"];
            var input = userId + salt;
            var sha1 = SHA1.Create();

            return Convert.ToHexString(sha1.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }

    }
}

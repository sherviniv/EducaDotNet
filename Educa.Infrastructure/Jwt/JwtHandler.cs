using Educa.Application.Common.Models.BaseModels;
using Educa.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Educa.Infrastructure.Jwt
{
    public class JwtHandler : IJwtHandler
    {
        private readonly AppSettings _appSettings;

        public JwtHandler(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string Generate(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Jwt.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                       new Claim("UserID",user.Id)
                }),
                Issuer = _appSettings.Jwt.Issuer,
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.Jwt.ExpiryMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

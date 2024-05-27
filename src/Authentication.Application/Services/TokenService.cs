using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Authentication.Domain.Entities;
using Authentication.Domain.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtConfig JwtConfig;
        public TokenService(IOptions<JwtConfig> jwtConfig)
        {
            JwtConfig = jwtConfig.Value;
        }
        public string GetToken(string username)
        {
            using (RSA rsa = RSA.Create(2048))
            {
                // rsa.ImportRSAPrivateKey(new ReadOnlySpan<byte>(Convert.FromBase64String(JwtConfig.PrivateKey)), out _);
                // rsa.ImportRSAPublicKey(new ReadOnlySpan<byte>(Convert.FromBase64String(JwtConfig.PublicKey)), out _);

                var tokenHandler = new JwtSecurityTokenHandler();
                // RSAParameters rsaParameters = rsa.ExportParameters(true);

                var privateKey = new RsaSecurityKey(rsa);

                var signingCredentials = new SigningCredentials(privateKey, SecurityAlgorithms.RsaSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    SigningCredentials = signingCredentials,
                    Expires = DateTime.UtcNow.AddMinutes(JwtConfig.Expires),
                    Issuer = "ms-authentication",
                    Audience = "ms-contacts",
                    Subject = new ClaimsIdentity(claims)
                };

                var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }
}
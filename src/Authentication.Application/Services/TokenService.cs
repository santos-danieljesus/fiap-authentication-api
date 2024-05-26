using Authentication.Domain.Entities;
using Authentication.Domain.Services;
using Microsoft.Extensions.Options;

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
            
            throw new System.NotImplementedException();
        }
    }
}
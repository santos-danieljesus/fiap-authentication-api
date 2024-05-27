using System.Threading;
using System.Threading.Tasks;
using Authentication.Domain.Services;
using MediatR;
using Template.Domain.Entities;
using Template.Domain.Services;

namespace Template.Application.Commands.Authentication
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationRequest, AuthenticationResponse>
    {
        protected readonly IAuthenticationService<AuthenticateUser> AuthenticationService;
        protected readonly ITokenService TokenService;

        public AuthenticationHandler(IAuthenticationService<AuthenticateUser> authenticationService, ITokenService tokenService)
        {
            AuthenticationService = authenticationService;
            TokenService = tokenService;
        }
        public Task<AuthenticationResponse> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var response = AuthenticationService.AuthenticateUser(request.Username, request.Password);

            if (response.IsValid && !string.IsNullOrEmpty(response.Data.Username))
            {
                var token = TokenService.GetToken(response.Data.Username);
                return Task.FromResult(new AuthenticationResponse(token));
            }

            return Task.FromResult(new AuthenticationResponse(string.Empty));
        }
    }
}
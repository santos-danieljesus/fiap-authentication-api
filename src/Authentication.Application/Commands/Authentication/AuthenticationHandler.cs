using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Template.Domain.Services;

namespace Template.Application.Commands.Authentication
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationRequest, AuthenticationResponse>
    {
        protected readonly IAuthenticationService AuthenticationService;

        public AuthenticationHandler(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }
        public Task<AuthenticationResponse> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            AuthenticationService.AuthenticateUser(request.Username, request.Password);
            throw new System.NotImplementedException();
        }
    }
}
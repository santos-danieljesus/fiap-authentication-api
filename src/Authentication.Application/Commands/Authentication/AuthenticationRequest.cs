using MediatR;

namespace Template.Application.Commands.Authentication
{
    public class AuthenticationRequest : IRequest<AuthenticationResponse>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
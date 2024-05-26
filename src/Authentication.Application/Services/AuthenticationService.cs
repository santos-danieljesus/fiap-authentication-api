using Authentication.Domain.Repository;
using Microsoft.Extensions.Logging;
using Template.Domain.Services;

namespace Template.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        protected ILogger<AuthenticationService> Logger { get;}
        protected IReadRepository ReadRepository;
        protected IWriteRepository WriteRepository;
        public AuthenticationService(ILogger<AuthenticationService> logger, IReadRepository readRepository, IWriteRepository writeRepository)
        {
            Logger = logger;
            ReadRepository = readRepository;
            WriteRepository = writeRepository;
        }
        public void AuthenticateUser(string username, string password)
        {
            ReadRepository.GetUser(username);
            throw new System.NotImplementedException();
        }

        public void DeleteUser(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterNewUser(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePassword(string username, string password, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(string username, string newUsername, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
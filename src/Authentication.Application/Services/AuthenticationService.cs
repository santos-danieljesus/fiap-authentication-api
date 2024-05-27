using Authentication.Domain.Entities;
using Authentication.Domain.Repository;
using Microsoft.Extensions.Logging;
using Template.Domain.Entities;
using Template.Domain.Services;

namespace Template.Application.Services
{
    public class AuthenticationService : IAuthenticationService<AuthenticateUser>
    {
        protected ILogger<AuthenticationService> Logger { get;}
        protected IReadRepository<AuthenticateUser> ReadRepository;
        protected IWriteRepository WriteRepository;
        public AuthenticationService(ILogger<AuthenticationService> logger, IReadRepository<AuthenticateUser> readRepository, IWriteRepository writeRepository)
        {
            Logger = logger;
            ReadRepository = readRepository;
            WriteRepository = writeRepository;
        }
        public ApiResponse<AuthenticateUser> AuthenticateUser(string username, string password)
        {
            ApiResponse<AuthenticateUser> user = ReadRepository.GetUser(username);

            if (user.IsValid && !string.IsNullOrEmpty(user.Data.Password))
            {
                if (user.Data.Password.Equals(password))
                    return user;
            }

            return new ApiResponse<AuthenticateUser>(false, new AuthenticateUser());
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
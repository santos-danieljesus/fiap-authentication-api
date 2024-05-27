using Authentication.Domain.Entities;

namespace Template.Domain.Services
{
    public interface IAuthenticationService<T>
    {
        void RegisterNewUser(string username, string password);
        ApiResponse<T> AuthenticateUser(string username, string password);
        void UpdateUser(string username, string newUsername, string password);
        void UpdatePassword(string username, string password, string newPassword);
        void DeleteUser(string username, string password);
    }
}
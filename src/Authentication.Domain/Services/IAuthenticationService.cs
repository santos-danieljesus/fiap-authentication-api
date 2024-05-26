namespace Template.Domain.Services
{
    public interface IAuthenticationService
    {
        void RegisterNewUser(string username, string password);
        void AuthenticateUser(string username, string password);
        void UpdateUser(string username, string newUsername, string password);
        void UpdatePassword(string username, string password, string newPassword);
        void DeleteUser(string username, string password);
    }
}
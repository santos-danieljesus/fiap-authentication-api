namespace Authentication.Domain.Services
{
    public interface ITokenService
    {
        string GetToken(string username);
    }
}
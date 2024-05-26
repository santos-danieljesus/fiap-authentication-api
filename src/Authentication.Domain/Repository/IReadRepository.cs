using Template.Domain.Entities;

namespace Authentication.Domain.Repository
{
    public interface IReadRepository
    {
        AuthenticateUser GetUser(string username);
    }
}
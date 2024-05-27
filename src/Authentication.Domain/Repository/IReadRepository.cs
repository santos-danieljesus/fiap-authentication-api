using Authentication.Domain.Entities;

namespace Authentication.Domain.Repository
{
    public interface IReadRepository<T>
    {
        ApiResponse<T> GetUser(string username);
    }
}
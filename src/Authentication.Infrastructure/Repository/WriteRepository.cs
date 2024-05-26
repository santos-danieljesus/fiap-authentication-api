using System.Data;
using Authentication.Domain.Repository;

namespace Authentication.Infrastructure.Repository
{
    public class WriteRepository : IWriteRepository
    {
        private readonly IDbConnection _context;

        public WriteRepository(IDbConnection context)
        {
            _context = context;
        }

        public void RegisterUser()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
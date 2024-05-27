using System;
using System.Data;
using Microsoft.Extensions.Logging;
using Authentication.Domain.Repository;
using Template.Domain.Entities;
using Dapper;
using System.Linq;
using Authentication.Domain.Entities;

namespace Authentication.Infrastructure.Repository
{
    public class ReadRepository : IReadRepository<AuthenticateUser>
    {
        protected readonly IDbConnection Connection;
        protected ILogger<ReadRepository> Logger;

        public ReadRepository(IDbConnection connection, ILogger<ReadRepository> logger)
        {
            Connection = connection;
            Logger = logger;
        }

        public ApiResponse<AuthenticateUser> GetUser(string username)
        {
            try
            {
                var user = Connection.Query<AuthenticateUser>(
                    "SELECT * FROM TB_AUTHENTICATION WHERE USERNAME = @username",
                    new {
                        @username = username
                    }).FirstOrDefault();
                
                if (user == null)
                    return new ApiResponse<AuthenticateUser>(false, new AuthenticateUser());

                return new ApiResponse<AuthenticateUser>(true, user);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error to query username");
                return new ApiResponse<AuthenticateUser>(false, new AuthenticateUser());
            }
        }
    }
}
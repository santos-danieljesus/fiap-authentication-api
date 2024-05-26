using System;
using System.Data;
using Microsoft.Extensions.Logging;
using Authentication.Domain.Repository;
using Template.Domain.Entities;
using Dapper;
using System.Linq;

namespace Authentication.Infrastructure.Repository
{
    public class ReadRepository : IReadRepository
    {
        protected readonly IDbConnection Connection;
        protected ILogger<ReadRepository> Logger;

        public ReadRepository(IDbConnection connection, ILogger<ReadRepository> logger)
        {
            Connection = connection;
            Logger = logger;
        }

        public AuthenticateUser GetUser(string username)
        {
            try
            {
                Connection.Open();
                var user = Connection.Query<AuthenticateUser>(
                    "SELECT * FROM AUT.TB_AUTHENTICATION WHERE USERNAME = @username", 
                    new {
                        @username
                    }
                ).FirstOrDefault();

                if (user == null)
                {
                    return new AuthenticateUser();
                }

                return user;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error to query username");
                return new AuthenticateUser();
            }
            finally
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}
using System.Data;

namespace AsyncApi.Infrastructure.Database.Repositories;

public interface IDbConnectionFactory
{
    IDbConnection GetConnection(string key = DbConnectionConfiguration.DefaultKey);
}
using System.Data;
using System.Data.Common;
using Npgsql;

namespace AsyncApi.Infrastructure.Database.Repositories;

public class DbConnectionFactory : IDbConnectionFactory
{
    static DbConnectionFactory()
    {
        DbProviderFactories.RegisterFactory("Npgsql", NpgsqlFactory.Instance);
    }
    
    public DbConnectionFactory(IConfiguration configuration, string sectionName)
    {
        Configuration = configuration.GetRequiredSection(sectionName);
    }
    
    protected IConfiguration Configuration { get; }

    public IDbConnection GetConnection(string key = DbConnectionConfiguration.DefaultKey)
    {
        var connectionConfiguration = Configuration.GetSection(key).Get<DbConnectionConfiguration>();
     
        var connection = DbProviderFactories
            .GetFactory(connectionConfiguration.Provider)
            .CreateConnection() ?? throw new InvalidOperationException();
        
        connection.ConnectionString = connectionConfiguration.ConnectionString;
        
        return connection;
    }
}
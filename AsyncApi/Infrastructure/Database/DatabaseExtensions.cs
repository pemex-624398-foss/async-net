using AsyncApi.Core.Model;
using AsyncApi.Infrastructure.Database.Repositories;

namespace AsyncApi.Infrastructure.Database;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionFactory>(provider =>
            new DbConnectionFactory(provider.GetRequiredService<IConfiguration>(), "Infrastructure:Database"));

        services.AddTransient<IEmpleadoRepository>(provider =>
            new EmpleadoRepository(provider.GetRequiredService<IDbConnectionFactory>(), "Default"));
        
        return services;
    }
}
using System.Data;
using AsyncApi.Core.Model;
using Dapper;

namespace AsyncApi.Infrastructure.Database.Repositories;

public class EmpleadoRepository : DbRepository<Empleado, int>, IEmpleadoRepository
{
    public EmpleadoRepository(IDbConnectionFactory connectionFactory, string connectionKey = DbConnectionConfiguration.DefaultKey) : base(connectionFactory, connectionKey)
    {
    }

    public EmpleadoRepository(IDbTransaction transaction) : base(transaction)
    {
    }

    public override async Task InsertAsync(Empleado entity)
    {
        using var connection = GetConnection();

        var idEmpleado = await connection.QuerySingleOrDefaultAsync<int>(
            "insert into empleado " +
            "(id_empleado, rfc, nombre, apellido, genero, fecha_nacimiento, correo) " +
            "values " +
            "(default, @Rfc, @Nombre, @Apellido, @Genero, @FechaNacimiento, @Correo) " +
            "returning id_empleado",
            entity,
            commandType: CommandType.Text
            );
        
        entity.IdEmpleado = idEmpleado;
    }
}
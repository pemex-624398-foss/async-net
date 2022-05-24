using System.Data;
using AsyncApi.Core.Model;
using CaseExtensions;
using Dapper;

namespace AsyncApi.Infrastructure.Database.Repositories;

public class EmpleadoRepository : DbRepository<Empleado, Guid>, IEmpleadoRepository
{
    public EmpleadoRepository(IDbConnectionFactory connectionFactory, string connectionKey) : base(connectionFactory, connectionKey)
    {
    }

    public EmpleadoRepository(IDbTransaction transaction) : base(transaction)
    {
    }

    public async Task<IEnumerable<Empleado>> GetAllAsync(CancellationToken cancellationToken)
    {
        using var connection = GetConnection();
        return await connection.QueryAsync<Empleado>(
            "select " +
            "id_empleado as IdEmpleado, " +
            "nombre as Nombre, " +
            "apellido as Apellido, " +
            "genero as Genero, " +
            "fecha_nacimiento as FechaNacimiento, " +
            "rfc as Rfc, " +
            "correo as Correo, " +
            "registro_confirmado as RegistroConfirmado " +
            "from empleado"
            );
    }

    public override async Task InsertAsync(Empleado entity, CancellationToken cancellationToken)
    {
        using var connection = GetConnection();

        await connection.ExecuteAsync(
            "insert into public.empleado " +
            "(id_empleado, nombre, apellido, genero, fecha_nacimiento, rfc, correo) " +
            "values " +
            "(@IdEmpleado, @Nombre, @Apellido, @Genero, @FechaNacimiento, @Rfc, @Correo)",
            entity,
            commandType: CommandType.Text
            );
    }

    public override async Task PatchAsync(Guid id, string propertyName, object value, CancellationToken cancellationToken)
    {
        // this-is-kebab-case (URL)
        // thisIsCamelCase (Javascript properties and variables, C# variables)
        // ThisIsPascalCase (C# clases and properties, MS SQL Server)
        // this_is_snake_case (PostgreSQL, MySQL, MariaDB, etc)
        // THIS_IS_MACRO_CASE (Java constants and enums)
        // This-Is-Train-Case
        var columnName = propertyName.ToSnakeCase();
        
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            $"update empleado set {columnName} = @Value where id_empleado = @IdEmpleado",
            new
            {
                Value = value,
                IdEmpleado = id
            }
            );
    }
}
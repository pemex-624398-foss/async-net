namespace AsyncApi.Core.Model;

public interface IEmpleadoRepository : IRepository<Empleado, Guid>
{
    Task<IEnumerable<Empleado>> GetAllAsync(CancellationToken cancellationToken);
}
using AsyncApi.Core.Model;

namespace AsyncApi.Core.UseCases;

public class RegistrarEmpleadoCommand
{
    public record Argument(
        string Rfc,
        string Nombre, string Apellido, string? Genero, DateTime? FechaNacimiento, 
        string Correo);
    public record Result(int EmpleadoId);


    private readonly IEmpleadoRepository _empleadoRepository;

    public RegistrarEmpleadoCommand(IEmpleadoRepository empleadoRepository)
    {
        _empleadoRepository = empleadoRepository;
    }

    public async Task<Result> Execute(Argument argument)
    {
        var empleado = new Empleado
        {
            Rfc = argument.Rfc,
            Nombre = argument.Nombre,
            Apellido = argument.Apellido,
            Genero = argument.Genero,
            FechaNacimiento = argument.FechaNacimiento,
            Correo = argument.Correo
        };

        await _empleadoRepository.InsertAsync(empleado);

        return new Result(empleado.IdEmpleado);
    }
}
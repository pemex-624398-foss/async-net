namespace AsyncApi.Core.Model;

public class Empleado
{
    public Guid IdEmpleado { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public string Rfc { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public bool RegistroConfirmado { get; set; }
}
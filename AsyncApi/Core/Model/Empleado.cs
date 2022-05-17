namespace AsyncApi.Core.Model;

public class Empleado
{
    public int IdEmpleado { get; set; }
    public string Rfc { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string? Genero { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string Correo { get; set; } = string.Empty;
    public bool AcuseGenerado { get; set; }
    public bool CredencialGenerada { get; set; }
    public bool NotificacionEnviada { get; set; }
}
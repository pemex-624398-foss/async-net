using AsyncApi.Core.UseCases;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace AsyncApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpleadoController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly RegistrarEmpleadoCommand _registrarEmpleadoCommand;

    public EmpleadoController(RegistrarEmpleadoCommand registrarEmpleadoCommand)
    {
        _logger = Log.ForContext<EmpleadoController>();
        _registrarEmpleadoCommand = registrarEmpleadoCommand;
    }

    [HttpPost]
    public IActionResult CrearRegistro([FromBody] RegistrarEmpleadoCommand.Argument argument)
    {
        _logger.Debug("Registro de empleado solicitado: {@Argument}", argument);
        var result = _registrarEmpleadoCommand.Execute(argument);
        _logger.Debug("Registro de empleado creado: {@Result}", result);
        return Ok(result);
    }
}
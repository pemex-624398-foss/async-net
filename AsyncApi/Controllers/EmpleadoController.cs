using AsyncApi.Core.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace AsyncApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpleadoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger _logger;

    public EmpleadoController(IMediator mediator)
    {
        _mediator = mediator;
        _logger = Log.ForContext<EmpleadoController>();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.Debug("GetEmpleadoListQuery recibida");
        Thread.Sleep(2000);
        var result = await _mediator.Send(new GetEmpleadoListQuery.Argument());
        _logger.Debug("GetEmpleadoListQuery ejecutada: {@ResultCount}", result.Count());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CrearRegistro([FromBody] RegistrarEmpleadoCommand.Argument argument)
    {
        _logger.Debug("Registro de empleado solicitado: {@Argument}", argument);
        var result = await _mediator.Send(argument);
        _logger.Debug("Registro de empleado creado: {@Result}", result);
        return Ok(result);
    }
}
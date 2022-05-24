using System.Runtime.Serialization;
using AsyncApi.Core.Model;
using FluentValidation;
using Hangfire;
using MediatR;

namespace AsyncApi.Core.UseCases;

public class RegistrarEmpleadoCommand : IRequestHandler<RegistrarEmpleadoCommand.Argument, RegistrarEmpleadoCommand.Result>
{
    public record Argument(
        string Nombre,
        string Apellido,
        string Genero, 
        DateTime FechaNacimiento,
        string Rfc,
        string Correo
        ) : IRequest<Result>;

    public class ArgumentValidator : AbstractValidator<Argument>
    {
        public ArgumentValidator()
        {
            RuleFor(a => a.Nombre).NotEmpty().MaximumLength(100);
            RuleFor(a => a.Apellido).NotEmpty().MaximumLength(100);
            RuleFor(a => a.Genero).NotEmpty().MaximumLength(100);
            RuleFor(a => a.Rfc).NotEmpty().MaximumLength(13);
            RuleFor(a => a.Correo).NotEmpty().MaximumLength(255);
        }
    }
    public record Result(Guid IdEmpleado);


    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly IMediator _mediator;

    public RegistrarEmpleadoCommand(IEmpleadoRepository empleadoRepository, IMediator mediator)
    {
        _empleadoRepository = empleadoRepository;
        _mediator = mediator;
    }

    public async Task<Result> Handle(Argument request, CancellationToken cancellationToken)
    {
        var empleado = new Empleado
        {
            IdEmpleado = Guid.NewGuid(),
            Rfc = request.Rfc,
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Genero = request.Genero,
            FechaNacimiento = request.FechaNacimiento,
            Correo = request.Correo
        };

        await _empleadoRepository.InsertAsync(empleado, cancellationToken);

        BackgroundJob.Enqueue(() =>
            _mediator.Publish(new EmpleadoRegistradoEvent.Notification(empleado.IdEmpleado), default));

        return new Result(empleado.IdEmpleado);
    }
}
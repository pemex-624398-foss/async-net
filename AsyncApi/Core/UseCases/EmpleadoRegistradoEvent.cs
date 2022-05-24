using AsyncApi.Core.Model;
using FluentValidation;
using MediatR;

namespace AsyncApi.Core.UseCases;

public static class EmpleadoRegistradoEvent
{
    public record Notification(Guid IdEmpleado) : INotification;

    public class Handler : INotificationHandler<Notification>
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public Handler(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            Thread.Sleep(20000);
            await _empleadoRepository.PatchAsync(notification.IdEmpleado, "RegistroConfirmado", true, cancellationToken);
        }
    }
}
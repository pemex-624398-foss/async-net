using System.Runtime.Serialization;
using AsyncApi.Core.Model;
using FluentValidation;
using Hangfire;
using MediatR;

namespace AsyncApi.Core.UseCases;

public class GetEmpleadoListQuery : IRequestHandler<GetEmpleadoListQuery.Argument, IEnumerable<Empleado>>
{
    public record Argument : IRequest<IEnumerable<Empleado>>;
    
    private readonly IEmpleadoRepository _empleadoRepository;
    
    public GetEmpleadoListQuery(IEmpleadoRepository empleadoRepository)
    {
        _empleadoRepository = empleadoRepository;
    }

    public Task<IEnumerable<Empleado>> Handle(Argument request, CancellationToken cancellationToken)
    {
        return _empleadoRepository.GetAllAsync(cancellationToken);
    }
}
using MassTransit;
using MediatR;

namespace OPS.UseCases.Contracts.Abstractions
{
    [ExcludeFromTopology]
    public interface IMessage : IRequest
    {
        Guid Id { get; init; }
        DateTimeOffset TimeStamp { get; init; }
    }
}

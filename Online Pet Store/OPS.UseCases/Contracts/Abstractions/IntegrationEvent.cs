using MediatR;

namespace OPS.UseCases.Contracts.Abstractions
{
    public abstract record IntegrationEvent : IRequest
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.UtcNow;
    }
}

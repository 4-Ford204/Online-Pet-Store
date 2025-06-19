using MassTransit;

namespace OPS.UseCases.Contracts.Abstractions
{
    [ExcludeFromTopology]
    public abstract record IntegrationEvent : IMessage
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.UtcNow;
    }
}

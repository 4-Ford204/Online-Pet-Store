using MassTransit;
using MediatR;
using OPS.UseCases.Contracts.Abstractions;

namespace Pet.API.Abstractions.Consumers
{
    public abstract class BaseConsumer<TMessage> : IConsumer<TMessage> where TMessage : IntegrationEvent
    {
        protected ISender _sender;

        protected BaseConsumer(ISender sender)
        {
            _sender = sender;
        }

        public async Task Consume(ConsumeContext<TMessage> context)
        {
            await _sender.Send(context.Message, context.CancellationToken);
        }
    }
}

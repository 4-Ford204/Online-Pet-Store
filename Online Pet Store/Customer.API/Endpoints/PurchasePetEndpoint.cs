using Customer.API.Abstractions.Endpoints;
using MassTransit;
using MediatR;
using OPS.UseCases.Contracts.IntegrationEvents.Pets;
using OPS.UseCases.Requests.Customers.Commands;

namespace Customer.API.Endpoints
{
    public class PurchasePetEndpoint : BaseEndpoint<PurchasePetRequest, PurchasePetResponse>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PurchasePetEndpoint(IMediator mediator, IPublishEndpoint publishEndpoint) : base(mediator)
        {
            _publishEndpoint = publishEndpoint;
        }

        public override void Configure()
        {
            Post("/customer/purchase-pet");
            AllowAnonymous();
        }

        public override async Task HandleAsync(PurchasePetRequest request, CancellationToken ct)
        {
            var command = new PurchasePetCommand(request);
            var result = await _mediator.Send(command, ct);

            if (result.IsSuccess)
            {
                var petPurchasedIntegrationEvent = new PetPurchasedIntegrationEvent
                {
                    PetId = request.PetId,
                    CustomerId = request.CustomerId
                };

                await _publishEndpoint.Publish(petPurchasedIntegrationEvent, ct);
            }

            await HandleResultAsync(result, ct);
        }
    }
}

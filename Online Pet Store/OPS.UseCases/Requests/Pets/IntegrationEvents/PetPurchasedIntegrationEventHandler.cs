using MediatR;
using OPS.UseCases.Contracts.IntegrationEvents.Pets;
using OPS.UseCases.Interfaces.InternalServices.Pets;

namespace OPS.UseCases.Requests.Pets.IntegrationEvents
{
    public class PetPurchasedIntegrationEventHandler(IUpdatePet service) : IRequestHandler<PetPurchasedIntegrationEvent>
    {
        public async Task Handle(PetPurchasedIntegrationEvent request, CancellationToken cancellationToken)
        {
            await service.UpdateOwnerId(request.PetId, request.CustomerId);
        }
    }
}

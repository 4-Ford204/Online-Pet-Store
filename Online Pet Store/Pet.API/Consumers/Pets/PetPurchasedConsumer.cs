using MediatR;
using OPS.UseCases.Contracts.IntegrationEvents.Pets;
using Pet.API.Abstractions.Consumers;

namespace Pet.API.Consumers.Pets
{
    public class PetPurchasedConsumer : BaseConsumer<PetPurchasedIntegrationEvent>
    {
        public PetPurchasedConsumer(ISender sender) : base(sender) { }
    }
}

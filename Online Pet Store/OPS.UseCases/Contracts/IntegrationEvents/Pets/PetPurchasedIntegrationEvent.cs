using OPS.UseCases.Contracts.Abstractions;

namespace OPS.UseCases.Contracts.IntegrationEvents.Pets
{
    public record PetPurchasedIntegrationEvent : IntegrationEvent
    {
        public int PetId { get; set; }
        public int CustomerId { get; set; }
    }
}

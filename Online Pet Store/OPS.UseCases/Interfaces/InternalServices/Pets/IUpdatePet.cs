namespace OPS.UseCases.Interfaces.InternalServices.Pets
{
    public interface IUpdatePet
    {
        Task<bool> UpdateOwnerId(int petId, int customerId);
    }
}

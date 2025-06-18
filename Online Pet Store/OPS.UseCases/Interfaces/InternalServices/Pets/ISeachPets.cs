using OPS.UseCases.Requests.Pets.Queries;

namespace OPS.UseCases.Interfaces.InternalServices.Pets
{
    public interface ISeachPets
    {
        Task<List<SearchPetsResponse>> Execute(SearchPetsRequest request);
    }
}

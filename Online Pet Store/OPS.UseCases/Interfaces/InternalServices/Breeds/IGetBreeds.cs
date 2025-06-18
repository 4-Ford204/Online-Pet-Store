using OPS.UseCases.Requests.Breeds.Queries;

namespace OPS.UseCases.Interfaces.InternalServices.Breeds
{
    public interface IGetBreeds
    {
        Task<List<GetBreedsResponse>> Execute();
    }
}

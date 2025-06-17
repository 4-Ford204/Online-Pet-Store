using OPS.UseCases.Breeds;

namespace OPS.UseCases.Interfaces.InternalServices.Breeds
{
    public interface IGetBreeds
    {
        Task<List<GetBreedsResponse>> Execute();
    }
}

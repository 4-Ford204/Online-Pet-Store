using OPS.UseCases.Requests.Species.Queries;

namespace OPS.UseCases.Interfaces.InternalServices.Species
{
    public interface IGetSpecies
    {
        Task<List<GetSpeciesResponse>> Execute();
    }
}

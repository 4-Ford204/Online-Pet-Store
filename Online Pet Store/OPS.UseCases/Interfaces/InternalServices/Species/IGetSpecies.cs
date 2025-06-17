using OPS.UseCases.Species;

namespace OPS.UseCases.Interfaces.InternalServices.Species
{
    public interface IGetSpecies
    {
        Task<List<GetSpeciesResponse>> Execute();
    }
}

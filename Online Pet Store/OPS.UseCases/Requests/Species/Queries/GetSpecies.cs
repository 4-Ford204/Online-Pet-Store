using Ardalis.Result;
using Ardalis.SharedKernel;
using OPS.UseCases.Interfaces.InternalServices.Species;

namespace OPS.UseCases.Requests.Species.Queries
{
    public record GetSpeciesQuery : IQuery<Result<List<GetSpeciesResponse>>>;

    public class GetSpeciesHandler(IGetSpecies service) : IQueryHandler<GetSpeciesQuery, Result<List<GetSpeciesResponse>>>
    {
        public async Task<Result<List<GetSpeciesResponse>>> Handle(GetSpeciesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var species = await service.Execute();
                return Result.Success(species);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }

    public class GetSpeciesResponse
    {
        public required string Name { get; set; }
        public IEnumerable<string>? Breeds { get; set; }
    }
}

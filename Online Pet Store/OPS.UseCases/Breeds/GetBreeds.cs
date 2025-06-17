using Ardalis.Result;
using Ardalis.SharedKernel;
using OPS.UseCases.Interfaces.InternalServices.Breeds;

namespace OPS.UseCases.Breeds
{
    public record GetBreedsQuery : IQuery<Result<List<GetBreedsResponse>>>;

    public class GetBreedsHandler(IGetBreeds service) : IQueryHandler<GetBreedsQuery, Result<List<GetBreedsResponse>>>
    {
        public async Task<Result<List<GetBreedsResponse>>> Handle(GetBreedsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var breeds = await service.Execute();
                return Result.Success(breeds);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }

    public class GetBreedsResponse
    {
        public required string Name { get; set; }
        public string? Species { get; set; }
        public IEnumerable<string>? Pets { get; set; }
    }
}

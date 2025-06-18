using Ardalis.Result;
using Ardalis.SharedKernel;

namespace OPS.UseCases.Requests.Customers.Commands
{
    public record PurchasePetCommand(PurchasePetRequest Request) : ICommand<Result<PurchasePetResponse>>;

    public class PurchasePetHandler() : ICommandHandler<PurchasePetCommand, Result<PurchasePetResponse>>
    {
        public async Task<Result<PurchasePetResponse>> Handle(PurchasePetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new PurchasePetResponse
                {
                    CustomerId = request.Request.CustomerId,
                    PetId = request.Request.PetId,
                    Price = request.Request.Price,
                    PurchasedDate = DateTime.UtcNow
                };
                return Result.Success(result);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }

    public class PurchasePetRequest
    {
        public required int CustomerId { get; set; }
        public required int PetId { get; set; }
        public required decimal Price { get; set; }
    }

    public class PurchasePetResponse
    {
        public required int CustomerId { get; set; }
        public required int PetId { get; set; }
        public required decimal Price { get; set; }
        public required DateTime PurchasedDate { get; set; }
    }
}

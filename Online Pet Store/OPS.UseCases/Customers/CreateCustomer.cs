using Ardalis.Result;
using Ardalis.SharedKernel;
using OPS.UseCases.Interfaces.Customers;

namespace OPS.UseCases.Customers
{
    public record CreateCustomerCommand(CreateCustomerRequest Request) : ICommand<Result<CreateCustomerResponse>>;

    public class CreateCustomerHandler(ICreateCustomer service) : ICommandHandler<CreateCustomerCommand, Result<CreateCustomerResponse>>
    {
        public async Task<Result<CreateCustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await service.Execute(request.Request);
                return Result.Success(customer);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }

    public class CreateCustomerRequest()
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }

    public class CreateCustomerResponse
    {
        public required string Name { get; set; }
    }
}

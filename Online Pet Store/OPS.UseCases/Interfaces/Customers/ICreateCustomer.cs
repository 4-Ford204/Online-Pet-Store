using OPS.UseCases.Customers;

namespace OPS.UseCases.Interfaces.Customers
{
    public interface ICreateCustomer
    {
        Task<CreateCustomerResponse> Execute(CreateCustomerRequest request);
    }
}

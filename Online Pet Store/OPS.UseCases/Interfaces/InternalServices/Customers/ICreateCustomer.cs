using OPS.UseCases.Requests.Customers.Commands;

namespace OPS.UseCases.Interfaces.InternalServices.Customers
{
    public interface ICreateCustomer
    {
        Task<bool> IsEmailExist(string email);
        Task<CreateCustomerResponse> Execute(CreateCustomerRequest request);
    }
}

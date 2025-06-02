using OPS.UseCases.Customers;

namespace OPS.UseCases.Interfaces.Customers
{
    public interface ICreateCustomer
    {
        Task<bool> IsEmailExist(string email);
        Task<CreateCustomerResponse> Execute(CreateCustomerRequest request);
    }
}

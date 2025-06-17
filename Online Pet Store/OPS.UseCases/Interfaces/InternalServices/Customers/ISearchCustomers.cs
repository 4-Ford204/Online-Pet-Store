using OPS.UseCases.UseCases.Customers;

namespace OPS.UseCases.Interfaces.InternalServices.Customers
{
    public interface ISearchCustomers
    {
        Task<List<SearchCustomersResponse>> Execute(SearchCustomersRequest request);
    }
}

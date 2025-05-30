using OPS.UseCases.Customers;

namespace OPS.UseCases.Interfaces.Customers
{
    public interface ISearchCustomers
    {
        Task<List<SearchCustomersResponse>> Execute(SearchCustomersRequest request);
    }
}

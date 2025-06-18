using OPS.UseCases.Requests.Customers.Queries;

namespace OPS.UseCases.Interfaces.InternalServices.Customers
{
    public interface ISearchCustomers
    {
        Task<List<SearchCustomersResponse>> Execute(SearchCustomersRequest request);
    }
}

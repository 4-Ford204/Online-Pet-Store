using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OPS.Infrastructure.MSSQL;
using OPS.UseCases.Customers;
using OPS.UseCases.Interfaces.Customers;

namespace OPS.Infrastructure.Implementations.Customers
{
    [Service(ServiceLifetime.Scoped)]
    class SearchCustomersService : ISearchCustomers
    {
        private readonly DataContext dbContext;

        public SearchCustomersService(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<SearchCustomersResponse>> Execute(SearchCustomersRequest request)
        {
            var customers = dbContext.Customers.AsQueryable();

            if (request != null)
            {
                if (!string.IsNullOrEmpty(request.Name))
                {
                    customers = customers.Where(c => string.Concat(c.FirstName, c.LastName).Contains(request.Name, StringComparison.CurrentCultureIgnoreCase));
                }

                if (!string.IsNullOrEmpty(request.Email))
                {
                    customers = customers.Where(c => c.Email.Contains(request.Email));
                }

                if (!string.IsNullOrEmpty(request.Phone))
                {
                    customers = customers.Where(c => c.Phone != null && c.Phone.Contains(request.Phone));
                }

                if (!string.IsNullOrEmpty(request.Address))
                {
                    customers = customers.Where(c => c.Address != null && c.Address.Contains(request.Address));
                }
            }

            var result = await customers.Select(c => new SearchCustomersResponse
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address
            }).ToListAsync();

            return result;
        }
    }
}

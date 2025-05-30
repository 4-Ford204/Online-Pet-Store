using Microsoft.Extensions.DependencyInjection;
using OPS.Domain.Entities;
using OPS.Infrastructure.MSSQL;
using OPS.UseCases.Customers;
using OPS.UseCases.Interfaces.Customers;

namespace OPS.Infrastructure.Implementations.Customers
{
    [Service(ServiceLifetime.Scoped)]
    public class CreateCustomerService : ICreateCustomer
    {
        private readonly DataContext dbContext;

        public CreateCustomerService(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CreateCustomerResponse> Execute(CreateCustomerRequest request)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Phone = request.Phone,
                Address = request.Address
            };

            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();

            return new CreateCustomerResponse
            {
                Name = $"{customer.FirstName} {customer.LastName}"
            };
        }
    }
}

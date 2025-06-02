using MediatR;
using OPS.UseCases.Customers;

namespace Customer.API.Endpoints
{
    public class SearchCustomersEndpoint(IMediator mediator) : BaseEndpoint<SearchCustomersRequest, List<SearchCustomersResponse>>
    {
        public override void Configure()
        {
            Post("/customer/search");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SearchCustomersRequest request, CancellationToken ct)
        {
            var query = new SearchCustomersQuery(request);
            var result = await mediator.Send(query, ct);

            await HandleResultAsync(result, ct);
        }
    }
}

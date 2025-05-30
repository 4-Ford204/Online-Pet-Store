using FastEndpoints;
using MediatR;
using OPS.UseCases.Customers;

namespace Customer.API.Endpoints
{
    public class SearchCustomersEndpoint(IMediator mediator) : Endpoint<SearchCustomersRequest, List<SearchCustomersResponse>>
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

            if (result.IsSuccess)
            {
                await SendOkAsync(result.Value, ct);
            }
            else
            {
                await SendErrorsAsync(500, ct);

            }
        }
    }
}

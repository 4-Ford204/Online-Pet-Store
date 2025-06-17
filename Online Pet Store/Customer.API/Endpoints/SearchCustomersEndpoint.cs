using Customer.API.Processors.PostProcessors;
using Customer.API.Processors.PreProcessors;
using MediatR;
using OPS.UseCases.UseCases.Customers;

namespace Customer.API.Endpoints
{
    public class SearchCustomersEndpoint : BaseEndpoint<SearchCustomersRequest, List<SearchCustomersResponse>>
    {
        public SearchCustomersEndpoint(IMediator mediator) : base(mediator) { }

        public override void Configure()
        {
            Get("/customer/search");
            AllowAnonymous();
            PreProcessor<CachePreProcessor<SearchCustomersRequest>>();
            PostProcessor<CachePostProcessor<SearchCustomersRequest, List<SearchCustomersResponse>>>();
        }

        public override async Task HandleAsync(SearchCustomersRequest request, CancellationToken ct)
        {
            var query = new SearchCustomersQuery(request);
            var result = await _mediator.Send(query, ct);

            await HandleResultAsync(result, ct);
        }
    }
}

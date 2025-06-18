using Customer.API.Abstractions.Endpoints;
using MediatR;
using OPS.UseCases.Requests.Customers.Commands;

namespace Customer.API.Endpoints
{
    public class CreateCustomerEndpoint : BaseEndpoint<CreateCustomerRequest, CreateCustomerResponse>
    {
        public CreateCustomerEndpoint(IMediator mediator) : base(mediator) { }

        public override void Configure()
        {
            Post("/customer/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateCustomerRequest request, CancellationToken ct)
        {
            var command = new CreateCustomerCommand(request);
            var result = await _mediator.Send(command, ct);

            await HandleResultAsync(result, ct);
        }
    }
}

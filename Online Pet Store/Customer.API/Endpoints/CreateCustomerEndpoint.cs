using MediatR;
using OPS.UseCases.Customers;

namespace Customer.API.Endpoints
{
    public class CreateCustomerEndpoint(IMediator mediator) : BaseEndpoint<CreateCustomerRequest, CreateCustomerResponse>
    {
        public override void Configure()
        {
            Post("/customer/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateCustomerRequest request, CancellationToken ct)
        {
            var command = new CreateCustomerCommand(request);
            var result = await mediator.Send(command, ct);

            await HandleResultAsync(result, ct);
        }
    }
}

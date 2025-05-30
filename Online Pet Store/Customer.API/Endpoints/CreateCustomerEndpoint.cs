using FastEndpoints;
using MediatR;
using OPS.UseCases.Customers;

namespace Customer.API.Endpoints
{
    public class CreateCustomerEndpoint(IMediator mediator) : Endpoint<CreateCustomerRequest, CreateCustomerResponse>
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

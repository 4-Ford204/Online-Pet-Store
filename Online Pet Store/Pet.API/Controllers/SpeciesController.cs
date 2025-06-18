using MediatR;
using Microsoft.AspNetCore.Mvc;
using OPS.UseCases.Requests.Species.Queries;
using Pet.API.Abstractions.Controllers;

namespace Pet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeciesController : BaseController
    {
        public SpeciesController(ILogger<BaseController> logger, IMediator mediator) : base(logger, mediator) { }

        [HttpGet, Route("get-all-species")]
        public async Task<IActionResult> Get()
        {
            var query = await _mediator.Send(new GetSpeciesQuery());
            return HandleResultAsync(query);
        }
    }
}

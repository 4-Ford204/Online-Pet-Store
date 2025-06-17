using MediatR;
using Microsoft.AspNetCore.Mvc;
using OPS.UseCases.Pets;

namespace Pet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : BaseController
    {
        public PetController(ILogger<BaseController> logger, IMediator mediator) : base(logger, mediator) { }

        [HttpGet, Route("get-all-pets")]
        public async Task<IActionResult> Get()
        {
            var query = await _mediator.Send(new SearchPetsQuery(new SearchPetsRequest()));
            return HandleResultAsync(query);
        }
    }
}

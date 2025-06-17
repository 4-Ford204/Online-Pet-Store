using MediatR;
using Microsoft.AspNetCore.Mvc;
using OPS.UseCases.Breeds;

namespace Pet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreedController : BaseController
    {
        public BreedController(ILogger<BaseController> logger, IMediator mediator) : base(logger, mediator) { }

        [HttpGet, Route("get-all-breeds")]
        public async Task<IActionResult> Get()
        {
            var query = await _mediator.Send(new GetBreedsQuery());
            return HandleResultAsync(query);
        }
    }
}

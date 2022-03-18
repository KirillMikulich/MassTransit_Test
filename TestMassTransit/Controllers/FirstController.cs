using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using Shared.API.MassTransit;
using System.Threading.Tasks;
using TestMassTransit.Consumers;

namespace TestMassTransit.Controllers
{
    [ApiController]
    [Route("api/first")]
    public class FirstController : ControllerBase
    {
        private IBus _bus { get; set; }
        private readonly IMediator _mediator;
        public FirstController(IBus bus, IMediator mediator)
        {
            _bus = bus;
            _mediator = mediator;
        }

        [HttpGet("GetInfo")]
        public async Task<IActionResult> GetInfo(int id)
        {

            //var client = _mediator.CreateRequestClient<A>();
            //var response = await client.GetResponse<B>(new A { id = 1 });

            return Ok(await _mediator.send(new A(){ id = 1 }));
        }
    }
}

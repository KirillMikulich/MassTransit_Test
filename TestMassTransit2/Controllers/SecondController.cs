using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using Shared.API.MassTransit;
using System.Threading.Tasks;
using TestMassTransit2.Consumers;

namespace TestMassTransit2.Controllers
{
    [ApiController]
    [Route("api/second")]
    public class SecondController : ControllerBase
    {
        private IBus _bus { get; set; }
        private readonly IMediator _mediator;
        public SecondController(IBus bus, IMediator mediator)
        {
            _bus = bus;
            _mediator = mediator;
        }

        [HttpGet("GetSecond")]
        public async Task<IActionResult> GetInfo(string name)
        {
           // var client = _mediator.CreateRequestClient<C>();
           //var response = await client.GetResponse<D>(new C { Name = "Kirill" });

            return Ok(await _mediator.send(new C { Name = "Kirill" }));
        }
    }
}

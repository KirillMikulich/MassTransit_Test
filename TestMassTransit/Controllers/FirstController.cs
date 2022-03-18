using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TestMassTransit.Consumers;

namespace TestMassTransit.Controllers
{
    [ApiController]
    [Route("api/first")]
    public class FirstController : ControllerBase
    {
        private IMediator _mediator { get; set; }
        public FirstController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetInfo")]
        public async Task<IActionResult> GetInfo(int id)
        {
            var client = _mediator.CreateRequestClient<A>();
            var res = await client.GetResponse<B>(new A { id = 1 });
            return Ok(res.Message);
        }
    }
}

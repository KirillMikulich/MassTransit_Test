using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
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
            /*var client = _bus.CreateRequestClient<A>();
            var res = await client.GetResponse<B>(new A { id = 1 });*/


            //var response = await _requestClient.GetResponse<B>(new A { id = 1 });
            try
            {
                var client = _mediator.CreateRequestClient<A>();

                var response = await client.GetResponse<B>(new A { id = 1 });

            }
            catch (Exception e)
            {

            }

            try
            {
                var client = _bus.CreateRequestClient<A>();
                var res = await client.GetResponse<B>(new A { id = 1 });

            }
            catch (Exception e)
            {

            }



            return Ok();
        }
    }
}

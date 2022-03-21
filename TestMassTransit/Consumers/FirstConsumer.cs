using MassTransit;
using Shared.API.MassTransit;
using System;
using System.Threading.Tasks;
using TestMassTransit2.Consumers;

namespace TestMassTransit.Consumers
{
    public class A: IRequest<B>
    { 
        public int id { get; set; }
    }

    public class B
    {
        public string name { get; set; }
    }

    public class FirstConsumer: IConsumer<A>
    {
        private readonly IBus _bus;
        public FirstConsumer(IBus bus)
        {
            _bus = bus;
        }
        public async Task Consume(ConsumeContext<A> context)
        {
            var client = _bus.CreateRequestClient<C>();
            var request = client.GetResponse<D>(new C { Name = "Kirill" });

            try
            {
                var response = await request;
            }
            catch(Exception e)
            {

            }
            
            await context.RespondAsync<B>(new { name = "Kirill" });
        }
    }
}

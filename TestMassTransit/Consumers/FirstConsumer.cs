using MassTransit;
using Shared.API.MassTransit;
using System.Threading.Tasks;

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
        public async Task Consume(ConsumeContext<A> context)
        {
            await context.RespondAsync<B>(new { name = "Kirill" });
        }
    }
}

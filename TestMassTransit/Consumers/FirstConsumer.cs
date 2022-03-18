using MassTransit;
using System.Threading.Tasks;

namespace TestMassTransit.Consumers
{
    public class A
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

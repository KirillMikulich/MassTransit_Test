using MassTransit;
using Shared.API.MassTransit;
using System.Threading.Tasks;

namespace TestMassTransit2.Consumers
{
    public class C: IRequest<D>
    {
        public string Name { get; set; }
    }

    public class D
    {
        public string Text { get; set; }
    }

    public class SecondConsumer: IConsumer<C>
    {
        public async Task Consume(ConsumeContext<C> context)
        {
            await context.RespondAsync(new D() { Text = "Example Text" });
        }
    }
}

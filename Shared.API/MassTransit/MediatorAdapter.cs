using MassTransit.Mediator;
using System.Threading.Tasks;

namespace Shared.API.MassTransit
{
    public static class MediatorAdapter
    {
        public static async Task<TResponse> send<TResponse>(this IMediator mediator, IRequest<TResponse> request) where TResponse : class
        {
            var client = mediator.CreateRequest(request);
            var response = await client.GetResponse<TResponse>();
            return response.Message;
        }
    }
}

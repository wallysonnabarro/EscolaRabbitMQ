using EscolaRabbitMQ.Domain;
using MassTransit;

namespace EscolaRabbitMQ.Services
{
    public class MessagePublisher(IBus bus) : IMessagePublisher
    {
        public async Task<bool> ExecuteAsync(LivroDto dto, CancellationToken stoppingToken)
        {
            if (!stoppingToken.IsCancellationRequested)
            {
                await bus.Publish(dto, stoppingToken);
            }

            return true;
        }
    }
}

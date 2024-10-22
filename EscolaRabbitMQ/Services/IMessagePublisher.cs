using EscolaRabbitMQ.Domain;

namespace EscolaRabbitMQ.Services
{
    public interface IMessagePublisher
    {
        Task<bool> ExecuteAsync(LivroDto dto, CancellationToken stoppingToken);
    }
}

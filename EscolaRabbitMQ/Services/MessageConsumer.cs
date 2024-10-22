using EscolaRabbitMQ.Data;
using EscolaRabbitMQ.Domain;
using MassTransit;

namespace EscolaRabbitMQ.Services
{
    public class MessageConsumer(ILivroRepository repository) : IConsumer<LivroDto>
    {
        Task IConsumer<LivroDto>.Consume(ConsumeContext<LivroDto> context)
        {
            repository.GravarLivro(context.Message);

            return Task.CompletedTask;
        }
    }
}

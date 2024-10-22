using EscolaRabbitMQ.Domain;

namespace EscolaRabbitMQ.Data
{
    public interface ILivroRepository
    {
        Task<Result<bool>> GravarLivro(LivroDto dto);
    }
}

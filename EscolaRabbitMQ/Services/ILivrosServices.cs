using EscolaRabbitMQ.Domain;

namespace EscolaRabbitMQ.Services
{
    public interface ILivrosServices
    {
        Task<Result<bool>> ValidarDadosLivro(LivroDto livro);
    }
}

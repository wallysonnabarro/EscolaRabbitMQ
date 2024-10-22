using EscolaRabbitMQ.Domain;

namespace EscolaRabbitMQ.Services
{
    public class LivrosServices : ILivrosServices
    {
        public async Task<Result<bool>> ValidarDadosLivro(LivroDto livro)
        {
            if (livro.Nome.Equals(""))
            {
                return new Result<bool>(new Errors { mensagem = "Nome do livro é obrigatório." });
            }

            if (livro.Titulo.Equals(""))
            {
                return new Result<bool>(new Errors { mensagem = "Título do livro é obrigatório." });
            }

            return Result<bool>.Success;
        }
    }
}

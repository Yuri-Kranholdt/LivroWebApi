using WebApi.Dto.Livro;
using WebApi.Models;

namespace WebApi.Services.Livro
{
    public interface LivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros(); // traz todos os livros

        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int LivroId);

        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);

        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto autorEdicaoDto);

        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int LivroId);

        Task<ResponseModel<List<LivroModel>>> GetAllBookFromAutor(int autorID);
    }
}

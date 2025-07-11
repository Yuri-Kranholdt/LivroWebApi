using WebApi.Models;
using WebApi.Dto.Autor;

namespace WebApi.Services.Autor
{
    public interface AutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores(); // traz todos os autores

        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int AutorId);

        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int LivroId);

        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);

        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto);

        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int AutorId);


    }
}

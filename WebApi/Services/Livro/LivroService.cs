using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Autor;
using WebApi.Dto.Livro;
using WebApi.Models;

namespace WebApi.Services.Livro
{
    public class LivroService : LivroInterface
    {
        private readonly AppDbContext _context; // ligação com o banco de dados para usar na implementação dos métodos

        public LivroService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int LivroId)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livro.FirstOrDefaultAsync(x => x.Id == LivroId);

                if (livro == null) 
                {
                    resposta.Mensagem = "Livro não encontrado";
                }

                resposta.Dados = livro;
                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == livroCriacaoDto.AutorId);

                if (autor == null)
                {
                    resposta.Mensagem = "Favor cadastrar autor";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livro.ToListAsync();

                resposta.Mensagem = "Livro criado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto autorEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livro.FirstOrDefaultAsync(x => x.Id == autorEdicaoDto.Id);

                var new_autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == autorEdicaoDto.AutorId);


                if (new_autor == null || livro == null)
                {
                    resposta.Mensagem = "autor ou livro não encontrado";
                    return resposta;
                }

                livro.Titulo = autorEdicaoDto.titulo;
                livro.Autor = new_autor;

                _context.Livro.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livro.ToListAsync();
                resposta.Mensagem = "Livro atualizado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int LivroId)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livro.FirstOrDefaultAsync(x => x.Id == LivroId);
                if (livro == null)
                {
                    resposta.Mensagem = "Livro n encontrado";
                    return resposta;

                }
                _context.Livro.Remove(livro);
                await _context.SaveChangesAsync();


                resposta.Dados = await _context.Livro.ToListAsync();
                resposta.Mensagem = "Livro removido";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> GetAllBookFromAutor(int autorID)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {

                var livros = await _context.Livro.Where(x => x.Autor.Id == autorID).ToListAsync();

                if (livros == null)
                {
                    resposta.Mensagem = "autor não encontrado";
                    return resposta;
                }

                resposta.Dados = livros;
                resposta.Mensagem = $"livros encontrados";

                return resposta;
                

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livro.ToListAsync();

                resposta.Dados = livros;

                resposta.Mensagem = "Listagem de Livros";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }
    }
}

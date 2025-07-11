using WebApi.Models;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Dto.Autor;
using System.Collections.Generic;

namespace WebApi.Services.Autor
{
    public class AutorService : AutorInterface
    {
        private readonly AppDbContext _context; // ligação com o banco de dados para usar na implementação dos métodos

        public AutorService(AppDbContext context)
        {
            _context = context;
        }
    
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int AutorId)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == AutorId);

                if (autor == null) 
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "autor encontrado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int LivroId)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                //var livro = await _context.Livro.FirstOrDefaultAsync(x => x.Id == LivroId);
                var livro = await _context.Livro
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livrobanco => livrobanco.Id == LivroId);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "autor encontrado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel()
                {
                    Name = autorCriacaoDto.Name,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();

                resposta.Mensagem = "Autor criado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == autorEdicaoDto.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Autor não Encontrado";
                    return resposta;
                }

                autor.Name = autorEdicaoDto.Name;
                autor.Sobrenome = autorEdicaoDto.Sobrenome;

                _context.Autores.Update(autor);

                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();

                resposta.Mensagem = "Autor atualizado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int AutorId)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == AutorId);
                if (autor == null)
                {
                    resposta.Mensagem = "autor n encontrado";
                    return resposta;
                   
                }
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();


                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "autor removido";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>(); // carrega o modelo de resposta

            try 
            {
                var autores = await _context.Autores.ToListAsync(); // entra na tabela dos autores e tenta pegar todos assyncronamente

                resposta.Dados = autores;

                resposta.Mensagem = "Autores coletados";

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

using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.Livro;
using WebApi.Dto.Livro;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController: ControllerBase
    {
        private readonly LivroInterface _livroInterface;
        
        public LivroController(LivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros() 
        { 
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{id}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int id)
        {
            var livros = await _livroInterface.BuscarLivroPorId(id);
            return Ok(livros);
        }

        [HttpGet("GetAllBookFromAutor/{id}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> GetAllBookFromAutor(int id)
        {
            var livros = await _livroInterface.GetAllBookFromAutor(id);
            return Ok(livros);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livros = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livros);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livro)
        {
            var livros = await _livroInterface.EditarLivro(livro);
            return Ok(livros);
        }

        [HttpDelete("ExcluirLivro/{id}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int id)
        {
            var livros = await _livroInterface.ExcluirLivro(id);
            return Ok(livros);
        }
    }
}

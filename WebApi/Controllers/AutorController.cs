using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Autor;
using WebApi.Models;
using WebApi.Dto.Autor;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase // chamará os métodos implementados pelo service
    {

        private readonly AutorInterface _autorInterface;

        public AutorController(AutorInterface autorinferface) 
        { 
            _autorInterface = autorinferface; // acesso aos métodos
        
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        // retorna uma task actionresult q guarda uma ResponseModel q armazena uma lista dos autores coletados
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{id}")]

        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int id)
        {
            var autor = await _autorInterface.BuscarAutorPorId(id);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{id}")]

        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int id)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(id);
            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDto autor)
        {
            var autores = await _autorInterface.CriarAutor(autor);
            return Ok(autores);
        }

        [HttpDelete("ExcluirAutor/{id}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ExcluirAutor(int id)
        {
            var autor = await _autorInterface.ExcluirAutor(id);
            return Ok(autor);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutorEdicaoDto autoredição)
        {
            var autores = await _autorInterface.EditarAutor(autoredição);
            return Ok(autores);
        }
    }
}

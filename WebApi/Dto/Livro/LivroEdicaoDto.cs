using WebApi.Models;

namespace WebApi.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string titulo { get; set; }

        public int AutorId { get; set; }

    }
}

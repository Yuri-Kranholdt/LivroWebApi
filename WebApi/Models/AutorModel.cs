using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Sobrenome { get; set; }

        [JsonIgnore]
        public ICollection<LivroModel> livros { get; set; }
    }
}

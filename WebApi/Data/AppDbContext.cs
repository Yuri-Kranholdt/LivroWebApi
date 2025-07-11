using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AutorModel> Autores { get; set; }

        public DbSet<LivroModel> Livro { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
    }
}

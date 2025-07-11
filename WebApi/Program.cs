using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Services.Autor;
using WebApi.Services.Livro;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AutorInterface, AutorService>();// instrui a interface a saber que AutorService irá implementar seus métodos
builder.Services.AddScoped<LivroInterface, LivroService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); // pega a string de conexão DefaultConnection dentro de appsettings
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

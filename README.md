# 📚 API de Gerenciamento de Livros e Autores

Uma Web API RESTful desenvolvida com **ASP.NET Core**, que permite gerenciar livros e autores com operações CRUD completas.

---

## Tecnologias Utilizadas

- .NET 8.0 (ASP.NET Core)
- Entity Framework Core (ou Dapper)
- SQL Server
- Swagger (documentação interativa)

---

## Endpoints Disponíveis

### Livros :

GET -> /api/Livro/ListarLivros
GET -> /api/Livro/BuscarLivroPorId/{id}
GET -> /api/Livro/GetAllBookFromAutor/{id}
POST -> /api/Livro/CriarLivro
PUT -> /api/Livro/EditarLivro
DELETE -> /api/Livro/ExcluirLivro/{id}

### Autores:

GET -> /api/Autor/ListarAutores
GET -> /api/Autor/BuscarAutorPorId/{id}
GET -> /api/Autor/BuscarAutorPorIdLivro/{id}
POST -> /api/Autor/CriarAutor
DELETE -> /api/Autor/ExcluirAutor/{id}
PUT -> /api/Autor/EditarAutor

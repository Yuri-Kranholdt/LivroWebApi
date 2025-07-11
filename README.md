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

GET  =>  `/api/Livro/ListarLivros`<br>
GET  =>  `/api/Livro/BuscarLivroPorId/{id}`<br>
GET  =>  `/api/Livro/GetAllBookFromAutor/{id}`<br>
POST  =>  `/api/Livro/CriarLivro`<br>
PUT  =>  `/api/Livro/EditarLivro`<br>
DELETE  =>  `/api/Livro/ExcluirLivro/{id}`<br>

### Autores:

GET  =>  `/api/Autor/ListarAutores`<br>
GET  =>  `/api/Autor/BuscarAutorPorId/{id}`<br>
GET  =>  `/api/Autor/BuscarAutorPorIdLivro/{id}`<br>
POST  =>  `/api/Autor/CriarAutor`<br>
DELETE  =>  `/api/Autor/ExcluirAutor/{id}`<br>
PUT  =>  `/api/Autor/EditarAutor`<br>

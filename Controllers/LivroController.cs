using BibliotecaAPI.Data;
using BibliotecaAPI.Mappers.LivroMappers;
using BibliotecaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[Route("api/[controller]")] // Rotas para acessar o controller de livro
[ApiController] // Indica que a classe é um controller

public class LivroController : ControllerBase // LivroController herda de ControllerBase
{
    private readonly LivroRepository _livroContext; // Atributo para acessar o banco de dados
    public LivroController(LivroRepository livroContext)
    {
        this._livroContext = livroContext;
    }

    [HttpGet] // Método para retornar todos os livros
    public IActionResult ListarTodosLivros()
    {
        var livros = _livroContext.ListarTodosLivros().Select(livro => livro.ToLivroDto());
        // Busca todos os livros no banco de dados e transforma cada um dos objetos em DTOs de livro
        // OBS : Estudar execução adiada 
        return Ok(livros); // Retorna os livros
    }

    [HttpGet("{id}")] // Método para retornar um livro específico
    public IActionResult BuscarLivroId([FromRoute] int id)
    {
        var livro = _livroContext.PesquisarLivroPorId(id);

        if (livro == null)
        {
            return NotFound();
        }

        return Ok(livro.ToLivroDto());
    }
}

using BibliotecaAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[Route("api/[controller]")] // Rotas para acessar o controller de livro
[ApiController] // Indica que a classe é um controller

public class LivroController : ControllerBase // LivroController herda de ControllerBase
{
    private readonly ApplicationDBContext _context; // Atributo para acessar o banco de dados
    public LivroController(ApplicationDBContext context)
    {
        this._context = context;
    }

    [HttpGet] // Método para retornar todos os livros
    public IActionResult ListarTodosLivros()
    {
        var livros = _context.livros.ToList(); // Busca todos os livros no banco de dados
        // OBS : Estudar execução adiada 
        return Ok(livros); // Retorna os livros
    }

    [HttpGet("{id}")] // Método para retornar um livro específico
    public IActionResult BuscarLivroId([FromRoute] int id)
    {
        var livro = _context.livros.Find(id);

        if (livro == null)
        {
            return NotFound();
        }

        return Ok(livro);
    }
}

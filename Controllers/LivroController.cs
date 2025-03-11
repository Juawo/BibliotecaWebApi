using BibliotecaAPI.Data;
using BibliotecaAPI.Dtos.Emprestimo;
using BibliotecaAPI.Dtos.Livro;
using BibliotecaAPI.Mappers.LivroMappers;
using BibliotecaAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[Route("api/[controller]")] // Rotas para acessar o controller de livro
[ApiController] // Indica que a classe é um controller

public class LivroController : ControllerBase // LivroController herda de ControllerBase
{
    private readonly LivroRepository _livroRepository; // Atributo para acessar o banco de dados
    public LivroController(LivroRepository livroRepository)
    {
        this._livroRepository = livroRepository;
    }

    [HttpGet] // Método para retornar todos os livros
    public async Task<IActionResult> ListarTodosLivros()
    {
        var livros = (await _livroRepository.GetAllLivros()).Select(livro => livro.ToLivroDto());
        // Busca todos os livros no banco de dados e transforma cada um dos objetos em DTOs de livro
        // OBS : Estudar execução adiada 
        return Ok(livros); // Retorna os livros
    }

    [HttpGet("{id}")] // Método para retornar um livro específico
    public async Task<IActionResult> BuscarLivroId([FromRoute] int id)
    {
        var livro = await _livroRepository.GetLivroById(id);

        if (livro == null)
        {
            return NotFound();
        }

        return Ok(livro.ToLivroDto());
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarLivro([FromBody] CreateLivroRequestDto livroDto)
    {
        var livroModel = livroDto.ToLivroFromCreateDto();
        await _livroRepository.CreateLivro(livroModel);

        return CreatedAtAction(nameof(BuscarLivroId), new {id = livroModel.Id}, livroModel.ToLivroDto());

    }
}

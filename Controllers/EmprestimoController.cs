using BibliotecaAPI.Data;
using BibliotecaAPI.Dtos.Emprestimo;
using BibliotecaAPI.Mappers.EmprestimoMappers;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmprestimoController : ControllerBase
{
    private readonly EmprestimoRepository _emprestimoRepository;
    private readonly LivroRepository _livroRepository;
    private readonly UsuarioRepository _usuarioRepository;

    public EmprestimoController(EmprestimoRepository emprestimoRepository, LivroRepository livroRepository, UsuarioRepository usuarioRepository)
    {
        this._emprestimoRepository = emprestimoRepository;
        this._livroRepository = livroRepository;
        this._usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodosEmprestimos()
    {
        var emprestimos = (await _emprestimoRepository.GetAllEmprestimos()).Select(emprestimo => emprestimo.ToEmprestimoDto());
        return Ok(emprestimos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarEmprestimoId([FromRoute] int id)
    {
        var emprestimo = await _emprestimoRepository.GetEmprestimoById(id);
        if (emprestimo == null)
        {
            return NotFound();
        }

        return Ok(emprestimo.ToEmprestimoDto());
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarEmprestimo([FromBody] CreateEmprestimoRequestDto emprestimoDto)
    {
        if (emprestimoDto == null)
        {
            return BadRequest("Dados da requisição invalidos!");
        }

        var livro = await _livroRepository.GetLivroById(emprestimoDto.idLivro);
        Console.WriteLine($"Livro encontrado: {livro != null}");

        var usuario = await _usuarioRepository.GetUsuarioById(emprestimoDto.idUsuario);
        Console.WriteLine($"Usuário encontrado: {usuario != null}");

        if (livro == null || usuario == null)
        {
            return NotFound("Usuario ou livro não encontrado");
        }

        if (livro.isEmprestado)
        {
            return BadRequest("O livro já está emprestado.");
        }

        Emprestimo emprestimo = new(usuario, livro);
        await _emprestimoRepository.CreateEmprestimo(emprestimo);

        return CreatedAtAction(nameof(BuscarEmprestimoId), new { id = emprestimo.Id }, emprestimo.ToEmprestimoDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> AtualizarEmprestimo([FromRoute] int id, [FromBody] UpdateEmprestimoRequestDto emprestimoDto)
    {
        var emprestimo = await _emprestimoRepository.GetEmprestimoById(id);

        var livro = await _livroRepository.GetLivroById(emprestimoDto.idLivro);
        var usuario = await _usuarioRepository.GetUsuarioById(emprestimoDto.idUsuario);

        if (emprestimo == null)
        {
            return NotFound("Emprestimo não encontrado");
        }

        if (livro == null)
        {
            return NotFound("Livro associado ao emprestimo não encontrado");
        }

        if (usuario == null)
        {
            return NotFound("Usuario associado ao emprestimo não encontrado");
        }

        emprestimo.dataEmprestimo = emprestimoDto.dataEmprestimo;
        emprestimo.dataDevolucao = emprestimoDto.dataDevolucao;
        emprestimo.livro = livro;
        emprestimo.usuario = usuario;
        emprestimo.isDevolvido = emprestimoDto.isDevolvido;

        return Ok(emprestimo.ToEmprestimoDto());
    }

    [HttpPut("{id}/devolverEmprestimo")]
    public async Task<IActionResult> DevolverEmprestimo([FromRoute] int id)
    {
        var emprestimo = await _emprestimoRepository.GetEmprestimoById(id);

        if (emprestimo == null)
        {
            return NotFound("Emprestimo não encontrado!");
        }

        if (emprestimo.isDevolvido)
        {
            return BadRequest("Esse emprestimo já foi devolvido!");
        }

        emprestimo.dataDevolucao = DateTime.UtcNow;
        emprestimo.livro.isEmprestado = false;

        await _emprestimoRepository.UpdateEmprestimo(emprestimo);
        return Ok("Emprestimo devolvido com sucesso!");
    }

}

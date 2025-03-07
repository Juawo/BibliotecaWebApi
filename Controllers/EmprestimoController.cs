using BibliotecaAPI.Data;
using BibliotecaAPI.Mappers.EmprestimoMappers;
using BibliotecaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmprestimoController : ControllerBase
{
    private readonly EmprestimoRepository _emprestimoRepository;

    public EmprestimoController(EmprestimoRepository emprestimoRepository)
    {
        this._emprestimoRepository = emprestimoRepository;
    }

    [HttpGet]
    public IActionResult ListarTodosEmprestimos()
    {
        var emprestimos = _emprestimoRepository.ListarTodosEmprestimos().Select(emprestimo => emprestimo.ToEmprestimoDto());
        return Ok(emprestimos);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarEmprestimoId([FromRoute] int id)
    {
        var emprestimo = _emprestimoRepository.PesquisarEmprestimoPorId(id);
        if (emprestimo == null)
        {
            return NotFound();
        }

        return Ok(emprestimo.ToEmprestimoDto());
    }
}

using BibliotecaAPI.Data;
using BibliotecaAPI.Mappers.EmprestimoMappers;
using BibliotecaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmprestimoController : ControllerBase
{
    private readonly EmprestimoRepository _emprestimoContext;

    public EmprestimoController(EmprestimoRepository emprestimoContext)
    {
        this._emprestimoContext = emprestimoContext;
    }

    [HttpGet]
    public IActionResult ListarTodosEmprestimos()
    {
        var emprestimos = _emprestimoContext.ListarTodosLivros().Select(emprestimo => emprestimo.ToEmprestimoDto());
        return Ok(emprestimos);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarEmprestimoId([FromRoute] int id)
    {
        var emprestimo = _emprestimoContext.PesquisarLivroPorId(id);
        if (emprestimo == null)
        {
            return NotFound();
        }

        return Ok(emprestimo.ToEmprestimoDto());
    }
}

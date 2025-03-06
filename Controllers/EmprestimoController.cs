using BibliotecaAPI.Data;
using BibliotecaAPI.Mappers.EmprestimoMappers;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmprestimoController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public EmprestimoController(ApplicationDBContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public IActionResult ListarTodosEmprestimos()
    {
        var emprestimos = _context.emprestimos.ToList().Select(emprestimo => emprestimo.ToEmprestimoDto());
        return Ok(emprestimos);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarEmprestimoId([FromRoute] int id)
    {
        var emprestimo = _context.emprestimos.Find(id);
        if (emprestimo == null)
        {
            return NotFound();
        }

        return Ok(emprestimo.ToEmprestimoDto());
    }
}

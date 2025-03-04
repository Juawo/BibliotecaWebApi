using BibliotecaAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UsuarioControllers : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public UsuarioControllers(ApplicationDBContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public IActionResult ListarTodosUsuarios()
    {
        var usuarios = _context.usuarios.ToList();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarUsuarioId([FromRoute] int id)
    {
        var usuario = _context.usuarios.Find();

        if (usuario == null)
        {
            return NotFound();
        }

        return Ok(usuario);
    }
}

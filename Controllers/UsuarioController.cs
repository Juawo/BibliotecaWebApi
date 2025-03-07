using BibliotecaAPI.Data;
using BibliotecaAPI.Mappers.UsuarioMappers;
using BibliotecaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UsuarioController : ControllerBase
{
    private readonly UsuarioRepository _usuarioContext;
    public UsuarioController(UsuarioRepository usuarioContext)
    {
        this._usuarioContext = usuarioContext;
    }

    [HttpGet]
    public IActionResult ListarTodosUsuarios()
    {
        var usuarios = _usuarioContext.ListarTodosLivros().Select(usuario => usuario.ToUsuarioDto());
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarUsuarioId([FromRoute] int id)
    {
        var usuario = _usuarioContext.PesquisarLivroPorId(id);

        if (usuario == null)
        {
            return NotFound();
        }

        return Ok(usuario.ToUsuarioDto());
    }
}

using BibliotecaAPI.Data;
using BibliotecaAPI.Mappers.UsuarioMappers;
using BibliotecaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UsuarioController : ControllerBase
{
    private readonly UsuarioRepository _usuarioRepository;
    public UsuarioController(UsuarioRepository usuarioRepository)
    {
        this._usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public IActionResult ListarTodosUsuarios()
    {
        var usuarios = _usuarioRepository.ListarTodosLivros().Select(usuario => usuario.ToUsuarioDto());
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarUsuarioId([FromRoute] int id)
    {
        var usuario = _usuarioRepository.PesquisarLivroPorId(id);

        if (usuario == null)
        {
            return NotFound();
        }

        return Ok(usuario.ToUsuarioDto());
    }
}

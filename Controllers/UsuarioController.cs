using BibliotecaAPI.Data;
using BibliotecaAPI.Dtos.Usuario;
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
    public async Task<IActionResult> ListarTodosUsuarios()
    {
        var usuarios = (await _usuarioRepository.GetAllUsuarios()).Select(usuario => usuario.ToUsuarioDto());
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarUsuarioId([FromRoute] int id)
    {
        var usuario = await _usuarioRepository.GetUsuarioById(id);

        if (usuario == null)
        {
            return NotFound();
        }

        return Ok(usuario.ToUsuarioDto());
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarUsuario([FromBody] CreateUsuarioRequestDto usuarioDto)
    {
        var usuario = usuarioDto.ToUsuarioFromCreateDto();
        await _usuarioRepository.CreateUsuario(usuario);
        
        return CreatedAtAction(nameof(BuscarUsuarioId), new { id = usuario.Id }, usuario.ToUsuarioDto());
    }
}

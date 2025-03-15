using System.Collections;
using BibliotecaAPI.Data;
using BibliotecaAPI.Interfaces.Repositories;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDBContext _context;

    public UsuarioRepository(ApplicationDBContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllUsuarios()
    {
        var usuario = await _context.usuarios.ToListAsync();
        return usuario;
    }

    public async Task<Usuario?> GetUsuarioById(int id)
    {
        var usuario = await _context.usuarios.FindAsync(id);

        if (usuario == null)
        {
            return null;
        }

        return usuario;
    }

    public async Task CreateUsuario(Usuario usuario)
    {
        await _context.AddAsync(usuario);
        await _context.SaveChangesAsync();

    }

    public async Task UpdateUsuario(Usuario usuario)
    {
        _context.Update(usuario);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteUsuario(Usuario usuario)
    {
        _context.Remove(usuario);
        await _context.SaveChangesAsync();

    }
}

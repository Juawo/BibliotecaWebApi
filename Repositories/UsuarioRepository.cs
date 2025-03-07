using BibliotecaAPI.Data;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repositories;
public class UsuarioRepository
{
    private readonly ApplicationDBContext _context;

    public UsuarioRepository(ApplicationDBContext context)
    {
        this._context = context;
    }

    public List<Usuario> ListarTodosLivros()
    {
        var usuario = _context.usuarios.ToList();
        return usuario;
    }

    public Usuario? PesquisarLivroPorId(int id)
    {
        var usuario = _context.usuarios.Find(id);

        if (usuario == null)
        {
            return null;
        }

        return usuario;
    }
}

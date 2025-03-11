using BibliotecaAPI.Models;

namespace BibliotecaAPI.Interfaces.Repositories;
public interface IUsuarioRepository
{

    Task<IEnumerable<Usuario>> GetAllUsuarios();
    Task<Usuario?> GetUsuarioById(int id);
    Task CreateUsuario(Usuario usuario);
    Task UpdateUsuario(Usuario usuario);
    Task DeleteUsuario(int id);


}

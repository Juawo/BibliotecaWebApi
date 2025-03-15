using BibliotecaAPI.Models;

namespace BibliotecaAPI.Interfaces.Repositories;

public interface IEmprestimoRepository
{

    Task<IEnumerable<Emprestimo>> GetAllEmprestimos();
    Task<Emprestimo?> GetEmprestimoById(int idEmprestimo);
    Task<Emprestimo?> GetEmprestimoByUsuarioAndLivro(int idUsuario, int idLivro);
    Task<IEnumerable<Emprestimo>> GetHistoricoEmprestimoUsuario(Usuario usuario);
    Task CreateEmprestimo(Emprestimo emprestimo);
    Task UpdateEmprestimo(Emprestimo emprestimo);
    Task DeleteEmprestimo(Emprestimo emprestimo);
    Task DevolverEmprestimo(Emprestimo emprestimo);

}

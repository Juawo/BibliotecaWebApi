using BibliotecaAPI.Models;

namespace BibliotecaAPI.Interfaces.Repositories;

public interface IEmprestimoRepository
{

    Task<IEnumerable<Emprestimo>> GetAllEmprestimos();
    Task<Emprestimo> GetEmprestimoById(int idUsuario, int idLivro);
    Task<Emprestimo> GetEmprestimoByUsuarioAndLivro(int idUsuario, int idLivro);
    Task<IEnumerable<Emprestimo>> GetHistoricoEmprestimoUsuario(Usuario usuario);
    Task CreateEmprestimo(Livro livro);
    Task UpdateEmprestimo(Livro livro);
    Task DeleteEmprestimo(int id);
    Task DevolverEmprestimo(Emprestimo emprestimo);

}

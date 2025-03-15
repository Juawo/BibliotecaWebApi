using BibliotecaAPI.Models;

namespace BibliotecaAPI.Interfaces.Repositories;

public interface ILivroRepository
{
    Task<IEnumerable<Livro>> GetAllLivros();
    Task<Livro?> GetLivroById(int id);
    Task CreateLivro(Livro livro);
    Task UpdateLivro(Livro livro);
    Task DeleteLivro(Livro livro);
}

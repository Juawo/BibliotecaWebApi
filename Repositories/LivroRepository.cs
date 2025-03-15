using BibliotecaAPI.Data;
using BibliotecaAPI.Interfaces.Repositories;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories;
public class LivroRepository : ILivroRepository
{
    private readonly ApplicationDBContext _context;

    public LivroRepository(ApplicationDBContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Livro>> GetAllLivros()
    {
        var livros = await _context.livros.ToListAsync();
        return livros;
    }

    public async Task<Livro?> GetLivroById(int id)
    {
        var livro = await _context.livros.FindAsync(id);

        if (livro == null)
        {
            return null;
        }

        return livro;
    }

    public async Task CreateLivro(Livro livro)
    {
        await _context.AddAsync(livro);
        await _context.SaveChangesAsync();

    }

    public async Task UpdateLivro(Livro livro)
    {
        _context.Update(livro);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteLivro(Livro livro)
    {
        _context.Remove(livro);
        await _context.SaveChangesAsync();
    }
}

using BibliotecaAPI.Data;
using BibliotecaAPI.Interfaces.Repositories;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories;
public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly ApplicationDBContext _context;

    public EmprestimoRepository(ApplicationDBContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Emprestimo>> GetAllEmprestimos()
    {
        var emprestimos = await _context.emprestimos.AsNoTracking().Include(e => e.livro).Include(e => e.usuario).ToListAsync();
        return emprestimos;
    }

    public async Task<Emprestimo?> GetEmprestimoById(int idEmprestimo)
    {
        var emprestimo = await _context.emprestimos.AsNoTracking().Include(e => e.livro).Include(e => e.usuario).FirstOrDefaultAsync(e => e.Id == idEmprestimo);

        if (emprestimo == null)
        {
            return null;
        }

        return emprestimo;
    }

    public async Task<Emprestimo?> GetEmprestimoByUsuarioAndLivro(int idLivro, int idUsuario)
    {
        var emprestimo = await _context.emprestimos.AsNoTracking().Include(e => e.livro).Include(e => e.usuario).FirstOrDefaultAsync(e => e.livro.Id == idLivro && e.usuario.Id == idUsuario && e.isDevolvido == false);

        if (emprestimo == null)
        {
            return null;
        }

        return emprestimo;
    }

    public async Task<IEnumerable<Emprestimo>> GetHistoricoEmprestimoUsuario(Usuario usuario)
    {
        var emprestimos = await _context.emprestimos.AsNoTracking().Include(e => e.livro).Include(e => e.usuario).Where(e => e.usuario.Id == usuario.Id).ToListAsync();
        return emprestimos;
    }

    public async Task CreateEmprestimo(Emprestimo emprestimo)
    {
        await _context.AddAsync(emprestimo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmprestimo(Emprestimo emprestimo)
    {
        _context.Update(emprestimo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmprestimo(Emprestimo emprestimo)
    {
        _context.Remove(emprestimo);
        await _context.SaveChangesAsync();
    }

    public async Task DevolverEmprestimo(Emprestimo emprestimo)
    {
        var emprestimoBusca = await _context.emprestimos.FindAsync(emprestimo.Id);
        var livro = await _context.livros.FindAsync(emprestimo.livro.Id);

        if (emprestimoBusca != null && livro != null)
        {
            emprestimo.isDevolvido = true;
            _context.Update(emprestimo);

            livro.isEmprestado = false;
            _context.Update(livro);

            _context.SaveChanges();
        }
    }
}

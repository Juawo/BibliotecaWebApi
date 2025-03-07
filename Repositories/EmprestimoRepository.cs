using BibliotecaAPI.Data;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repositories;
public class EmprestimoRepository
{
    private readonly ApplicationDBContext _context;

    public EmprestimoRepository(ApplicationDBContext context)
    {
        this._context = context;
    }

    public List<Emprestimo> ListarTodosEmprestimos()
    {
        var emprestimos = _context.emprestimos.ToList();
        return emprestimos;
    }

    public List<Emprestimo>? ListarHistoricoEmprestimosUsuario(Usuario usuario)
    {
        var emprestimos = _context.emprestimos.Where(e => e.usuario.Id == usuario.Id).ToList();
        return emprestimos;
    }

    public Emprestimo? PesquisarEmprestimoPorId(int id)
    {
        var emprestimo = _context.emprestimos.Find(id);

        if (emprestimo == null)
        {
            return null;
        }

        return emprestimo;
    }

    public Emprestimo? PesquisarEmprestimoPorLivroEUsuario(Livro livro, Usuario usuario)
    {
        var emprestimo = _context.emprestimos.FirstOrDefault(e => e.livro.Id == livro.Id && e.usuario.Id == usuario.Id && e.isDevolvido == false);

        if (emprestimo == null)
        {
            return null;
        }

        return emprestimo;
    }

    public void CadastrarEmprestimo(Emprestimo emprestimo)
    {
        _context.Add(emprestimo);
        _context.SaveChanges();
    }

    public void AtualizarEmprestimo(Emprestimo emprestimo)
    {
        _context.Update(emprestimo);
        _context.SaveChanges();
    }

    public void RemoverEmprestimo(Emprestimo emprestimo)
    {
        _context.Remove(emprestimo);
        _context.SaveChanges();
    }

    public void DevolverEmprestimo(Emprestimo emprestimo)
    {
        var emprestimoBusca = _context.emprestimos.Find(emprestimo.Id);
        var livro = _context.livros.Find(emprestimo.livro.Id);

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

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

    public List<Emprestimo> ListarTodosLivros()
    {
        var emprestimos = _context.emprestimos.ToList();
        return emprestimos;
    }

    public Emprestimo? PesquisarLivroPorId(int id)
    {
        var emprestimo = _context.emprestimos.Find(id);

        if (emprestimo == null)
        {
            return null;
        }

        return emprestimo;
    }
}

using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Repositories;
public class LivroRepository
{
    private readonly ApplicationDBContext _context;

    public LivroRepository(ApplicationDBContext context)
    {
        this._context = context;
    }

    public List<Livro> ListarTodosLivros()
    {
        var livros = _context.livros.ToList();
        return livros;
    }

    public Livro? PesquisarLivroPorId(int id)
    {
        var livro = _context.livros.Find(id);

        if (livro == null)
        {
            return null;
        }

        return livro;
    }
}

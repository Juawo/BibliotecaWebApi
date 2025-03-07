using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Usuario> usuarios {get; set;}
    public DbSet<Livro> livros {get; set;}
    public DbSet<Emprestimo> emprestimos {get; set;}
}
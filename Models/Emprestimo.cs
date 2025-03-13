namespace BibliotecaAPI.Models;

public class Emprestimo
{
    public int Id { get; set; }
    public Usuario usuario { get; set; }
    public Livro livro { get; set; }
    public DateTime dataEmprestimo { get; set; }
    public DateTime dataDevolucao { get; set; }
    public bool isDevolvido { get; set; }

    public Emprestimo() { }

    public Emprestimo(Usuario usuario, Livro livro)
    {
        this.usuario = usuario;
        this.livro = livro;
        this.dataEmprestimo = DateTime.UtcNow;
        this.dataDevolucao = this.dataEmprestimo.AddDays(7);
        this.isDevolvido = false;
    }

}

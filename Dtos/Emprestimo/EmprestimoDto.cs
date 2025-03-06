namespace BibliotecaAPI.Dtos.Emprestimo;
public class EmprestimoDto
{
    public int Id {get; set;}
    public int Id_usuario {get; set;}
    public int Id_livro { get; set; }
    public DateTime dataEmprestimo {get; set;}
    public DateTime dataDevolucao {get; set;}
    public bool isDevolvido {get; set;}
}

namespace BibliotecaAPI.Dtos.Emprestimo;
public class UpdateEmprestimoRequestDto
{
    public int idUsuario {get; set;}
    public int idLivro { get; set; }
    public DateTime dataEmprestimo {get; set;}
    public DateTime dataDevolucao {get; set;}
    public bool isDevolvido {get; set;}
}

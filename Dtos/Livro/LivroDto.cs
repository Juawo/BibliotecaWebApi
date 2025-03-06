namespace BibliotecaAPI.Dtos.Livro;
public class LivroDto
{
     public int Id {get; set;}
    public string titulo {get; set;}
    public string autor {get; set;}
    public string editora {get; set;}
    public int anoPublicacao {get; set;}
    public bool isEmprestado {get; set;}
}

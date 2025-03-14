namespace BibliotecaAPI.Models;

public class Livro
{
    public int Id { get; set; }
    public string titulo {get; set;}
    public string autor {get; set;}
    public string editora {get; set;}
    public int anoPublicacao {get; set;}
    public bool isEmprestado {get; set;}
    
    public Livro(){}

    public Livro(string titulo, string autor, string editora, int anoPublicacao)
    {
        this.titulo = titulo;
        this.autor = autor;
        this.editora = editora;
        this.anoPublicacao = anoPublicacao;
        this.isEmprestado = false;
    }

}

namespace BibliotecaAPI.Models;

public class Usuario
{
    public int Id {get; set;}
    public string nome {get; set;}
    public string cpf {get; set;}
    public string email {get; set;}

    public Usuario() { }

    public Usuario(string nome, string cpf, string email)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.email = email;
    }
    
}

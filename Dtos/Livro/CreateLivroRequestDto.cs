namespace BibliotecaAPI.Dtos.Livro;
public class CreateLivroRequestDto
{
    public string titulo {get; set;}
    public string autor {get; set;}
    public string editora {get; set;}
    public int anoPublicacao {get; set;}
}
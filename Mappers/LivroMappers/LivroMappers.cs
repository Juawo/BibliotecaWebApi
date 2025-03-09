using BibliotecaAPI.Dtos.Livro;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Mappers.LivroMappers;
public static class LivroMappers
{
    public static LivroDto ToLivroDto(this Livro livroModel)
    {
        return new LivroDto
        {
            Id = livroModel.Id,
            titulo = livroModel.titulo,
            autor = livroModel.autor,
            editora = livroModel.editora,
            anoPublicacao = livroModel.anoPublicacao,
            isEmprestado = livroModel.isEmprestado
        };
    }
    public static Livro ToLivroFromCreateDto(this CreateLivroRequestDto livroDto)
    {
        return new Livro
        {
            titulo = livroDto.titulo,
            autor = livroDto.autor,
            editora = livroDto.editora,
            anoPublicacao = livroDto.anoPublicacao
        };
    }
}

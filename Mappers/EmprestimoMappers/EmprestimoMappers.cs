using BibliotecaAPI.Dtos.Emprestimo;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Mappers.EmprestimoMappers;
public static class EmprestimoMappers
{
    public static EmprestimoDto ToEmprestimoDto(this Emprestimo empresitmoModel)
    {
        return new EmprestimoDto
        {
            Id = empresitmoModel.Id,
            Id_livro = empresitmoModel.livro.Id,
            Id_usuario = empresitmoModel.usuario.Id,
            dataEmprestimo = empresitmoModel.dataEmprestimo,
            dataDevolucao = empresitmoModel.dataDevolucao,
            isDevolvido = empresitmoModel.isDevolvido
        };
    }

    // public static Emprestimo ToEmprestimoModel(this EmprestimoDto emprestimoDto)
    // {
    //     return new Emprestimo
    //     {
    //         Id = emprestimoDto.Id,
    //         usuario = 

    //     }
    // }
}

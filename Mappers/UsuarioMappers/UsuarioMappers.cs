using BibliotecaAPI.Dtos.Usuario;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Mappers.UsuarioMappers;
public static class UsuarioMappers
{
    public static UsuarioDto ToUsuarioDto(this Usuario usuarioModel)
    {
        return new UsuarioDto
        {
            Id = usuarioModel.Id,
            nome = usuarioModel.nome,
            cpf = usuarioModel.cpf,
            email = usuarioModel.email
        };
    }
}

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
    public static Usuario ToUsuarioModel(this UsuarioDto usuarioDto)
    {
        return new Usuario
        {
            Id = usuarioDto.Id,
            nome = usuarioDto.nome,
            cpf = usuarioDto.cpf,
            email = usuarioDto.email
        };
    }
    public static Usuario ToUsuarioFromCreateDto(this CreateUsuarioRequestDto usuarioDto)
    {
        return new Usuario
        {
            nome = usuarioDto.nome,
            cpf = usuarioDto.cpf,
            email = usuarioDto.email
        };
    }
}

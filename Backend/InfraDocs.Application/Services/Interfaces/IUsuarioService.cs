using InfraDocs.Shared.Dtos.Usuario;

namespace InfraDocs.Application.Services.Interfaces
{
    public interface IUsuarioService
        : IBaseService<
            ReadUsuarioDto,
            CreateUsuarioDto,
            UpdateUsuarioDto>
    {
        Task<ReadUsuarioDto> GetByEmailAsync(string email);
    }
}

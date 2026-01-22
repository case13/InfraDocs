using InfraDocs.Shared.Dtos.Common;
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
        Task<PagedResultDto<ReadUsuarioDto>> GetPagedAsync(
                int pageNumber, int pageSize, string? filterColumn, string? filterText);
    }
}

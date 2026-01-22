using InfraDocs.Shared.Dtos.Common;
using InfraDocs.Shared.Dtos.Usuario;

namespace InfraDocs.BlazorServer.Services.Interfaces
{
    public interface IUsuarioApiService
    {
        Task<PagedResultDto<ReadUsuarioDto>> ObterPaginadoAsync(
            int pageNumber,
            int pageSize,
            string? colunaOrdenacao,
            string? termoBusca,
            CancellationToken ct = default);

        Task<IEnumerable<ReadUsuarioDto>> ObterTodosAsync();

        Task<ReadUsuarioDto> ObterPorIdAsync(int id);

        Task<bool> IncluirAsync(CreateUsuarioDto dto);

        Task<bool> EditarAsync(int id, UpdateUsuarioDto dto);

        Task<bool> ExcluirAsync(int id);
    }
}

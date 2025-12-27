using InfraDocs.Shared.Dtos.RequerimentoSuspensaoRestricao;

namespace InfraDocs.Application.Services.Interfaces
{
    public interface IRequerimentoSuspensaoRestricaoService
        : IBaseService<
            ReadRequerimentoSuspensaoRestricaoDto,
            CreateRequerimentoSuspensaoRestricaoDto,
            UpdateRequerimentoSuspensaoRestricaoDto>
    {
        Task<IEnumerable<ReadRequerimentoSuspensaoRestricaoDto>> GetByPessoaIdAsync(int pessoaId);
    }
}

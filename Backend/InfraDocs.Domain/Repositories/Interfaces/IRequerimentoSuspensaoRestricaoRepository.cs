using InfraDocs.Domain.Entities;

namespace InfraDocs.Domain.Repositories.Interfaces
{
    public interface IRequerimentoSuspensaoRestricaoRepository
        : IBaseRepository<RequerimentoSuspensaoRestricao>
    {
        Task<IEnumerable<RequerimentoSuspensaoRestricao>> GetByPessoaIdAsync(int pessoaId);
    }
}

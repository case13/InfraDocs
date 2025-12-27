using InfraDocs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfraDocs.Domain.Repositories.Interfaces
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        Task<Pessoa?> GetByDocumentoAsync(string documento);
    }
}

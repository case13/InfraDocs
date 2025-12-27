using InfraDocs.Domain.Entities;
using System.Threading.Tasks;

namespace InfraDocs.Domain.Repositories.Interfaces
{
    public interface IOrganizacaoRepository : IBaseRepository<Organizacao>
    {
        Task<Organizacao?> GetByDocumentoAsync(string documento);
    }
}

using InfraDocs.Domain.Entities;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InfraDocs.Infrastructure.Repositories.Implementations
{
    public class OrganizacaoRepository : BaseRepository<Organizacao>, IOrganizacaoRepository
    {
        public OrganizacaoRepository(InfraDocsDbContext context)
            : base(context)
        {
        }

        public async Task<Organizacao?> GetByDocumentoAsync(string documento)
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.Documento == documento);
        }
    }
}

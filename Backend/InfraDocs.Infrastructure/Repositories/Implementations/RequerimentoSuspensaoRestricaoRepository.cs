using InfraDocs.Domain.Currents.Interfaces;
using InfraDocs.Domain.Entities;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfraDocs.Infrastructure.Repositories.Implementations
{
    public class RequerimentoSuspensaoRestricaoRepository
        : BaseRepository<RequerimentoSuspensaoRestricao>,
          IRequerimentoSuspensaoRestricaoRepository
    {
        private readonly ICurrentOrganizacao _currentOrganizacao;

        public RequerimentoSuspensaoRestricaoRepository(
            InfraDocsDbContext context,
            ICurrentOrganizacao currentOrganizacao)
            : base(context)
        {
            _currentOrganizacao = currentOrganizacao;
        }

        public override async Task<RequerimentoSuspensaoRestricao?> GetByIdAsync(int id)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.OrganizacaoId == _currentOrganizacao.OrganizacaoId)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IEnumerable<RequerimentoSuspensaoRestricao>> GetAllAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.OrganizacaoId == _currentOrganizacao.OrganizacaoId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public override async Task<(IEnumerable<RequerimentoSuspensaoRestricao> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(x => x.OrganizacaoId == _currentOrganizacao.OrganizacaoId);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}

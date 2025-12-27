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
    public class UsuarioRepository
        : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ICurrentOrganizacao _currentOrganizacao;

        public UsuarioRepository(
            InfraDocsDbContext context,
            ICurrentOrganizacao currentOrganizacao)
            : base(context)
        {
            _currentOrganizacao = currentOrganizacao;
        }

        public async Task<Usuario?> GetByEmailForLoginAsync(string email)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public override async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.OrganizacaoId == _currentOrganizacao.OrganizacaoId)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.OrganizacaoId == _currentOrganizacao.OrganizacaoId)
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public override async Task<(IEnumerable<Usuario> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(x => x.OrganizacaoId == _currentOrganizacao.OrganizacaoId);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(x => x.Nome)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.OrganizacaoId == _currentOrganizacao.OrganizacaoId)
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}

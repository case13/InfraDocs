using InfraDocs.Domain.Currents.Interfaces;
using InfraDocs.Domain.Entities;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Infrastructure.Data;
using InfraDocs.Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PessoaRepository
    : BaseRepository<Pessoa>, IPessoaRepository
{
    private readonly ICurrentOrganizacao _currentOrganizacao;

    public PessoaRepository(
        InfraDocsDbContext context,
        ICurrentOrganizacao currentOrganizacao)
        : base(context)
    {
        _currentOrganizacao = currentOrganizacao;
    }

    public override async Task<Pessoa?> GetByIdAsync(int id)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => x.OrganizacaoId == _currentOrganizacao.OrganizacaoId)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<IEnumerable<Pessoa>> GetAllAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => x.OrganizacaoId == _currentOrganizacao.OrganizacaoId)
            .OrderBy(x => x.Nome)
            .ToListAsync();
    }

    public override async Task<(IEnumerable<Pessoa> Items, int TotalCount)> GetPagedAsync(
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

    public async Task<Pessoa?> GetByDocumentoAsync(string documento)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => x.OrganizacaoId == _currentOrganizacao.OrganizacaoId)
            .FirstOrDefaultAsync(x => x.Documento == documento);
    }
}
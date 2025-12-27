using InfraDocs.Domain.Entities;
using InfraDocs.Shared.Dtos.Organizacao;

namespace InfraDocs.Application.Services.Interfaces
{
    public interface IOrganizacaoService
        : IBaseService<
            ReadOrganizacaoDto,
            CreateOrganizacaoDto,
            UpdateOrganizacaoDto>
    {
        Task<ReadOrganizacaoDto?> GetByDocumentoAsync(string documento);
    }
}

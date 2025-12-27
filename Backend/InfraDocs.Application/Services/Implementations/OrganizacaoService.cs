using AutoMapper;
using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Domain.Entities;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Shared.Dtos.Organizacao;

namespace InfraDocs.Application.Services.Implementations
{
    public class OrganizacaoService
        : BaseService<
            Organizacao,
            ReadOrganizacaoDto,
            CreateOrganizacaoDto,
            UpdateOrganizacaoDto>,
          IOrganizacaoService
    {
        private readonly IOrganizacaoRepository _repository;
        public OrganizacaoService(
            IOrganizacaoRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<ReadOrganizacaoDto?> GetByDocumentoAsync(string documento)
        {
            try
            {
                var organizacao = await _repository.GetByDocumentoAsync(documento);
                if (organizacao == null)
                {
                    return new ReadOrganizacaoDto();
                }
                return _mapper.Map<ReadOrganizacaoDto>(organizacao);
            }
            catch (Exception)
            {
                return new ReadOrganizacaoDto();
            }
        }
    }
}

using AutoMapper;
using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Domain.Entities;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Shared.Dtos.RequerimentoSuspensaoRestricao;

namespace InfraDocs.Application.Services.Implementations
{
    public class RequerimentoSuspensaoRestricaoService
        : BaseService<
            RequerimentoSuspensaoRestricao,
            ReadRequerimentoSuspensaoRestricaoDto,
            CreateRequerimentoSuspensaoRestricaoDto,
            UpdateRequerimentoSuspensaoRestricaoDto>,
          IRequerimentoSuspensaoRestricaoService
    {
        private readonly IRequerimentoSuspensaoRestricaoRepository _repository;

        public RequerimentoSuspensaoRestricaoService(
            IRequerimentoSuspensaoRestricaoRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReadRequerimentoSuspensaoRestricaoDto>> GetByPessoaIdAsync(int pessoaId)
        {
            try
            {
                var requerimentos = await _repository.GetByPessoaIdAsync(pessoaId);
                if (requerimentos == null || !requerimentos.Any())
                    return Enumerable.Empty<ReadRequerimentoSuspensaoRestricaoDto>();
                return _mapper.Map<IEnumerable<ReadRequerimentoSuspensaoRestricaoDto>>(requerimentos);
            }
            catch (Exception)
            {
                return Enumerable.Empty<ReadRequerimentoSuspensaoRestricaoDto>();
            }
        }
    }
}

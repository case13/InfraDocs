using AutoMapper;
using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Domain.Entities;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Shared.Dtos.Pessoa;
using System;

namespace InfraDocs.Application.Services.Implementations
{
    public class PessoaService
        : BaseService<
            Pessoa,
            ReadPessoaDto,
            CreatePessoaDto,
            UpdatePessoaDto>,
          IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(
            IPessoaRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<ReadPessoaDto> GetByDocumentoAsync(string documento)
        {
            try
            {
                var pessoa = await _repository.GetByDocumentoAsync(documento);
                if (pessoa == null)
                    return new ReadPessoaDto();

                return _mapper.Map<ReadPessoaDto>(pessoa);
            }
            catch (Exception)
            {
                return new ReadPessoaDto();
            }
        }
    }
}

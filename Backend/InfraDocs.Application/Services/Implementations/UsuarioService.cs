using AutoMapper;
using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Domain.Entities;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Shared.Dtos.Usuario;
using System;
using System.Threading.Tasks;

namespace InfraDocs.Application.Services.Implementations
{
    public class UsuarioService
        : BaseService<
            Usuario,
            ReadUsuarioDto,
            CreateUsuarioDto,
            UpdateUsuarioDto>,
          IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(
            IUsuarioRepository repository,
            IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<ReadUsuarioDto> GetByEmailAsync(string email)
        {
            try
            {
                var usuario = await _repository.GetByEmailAsync(email);
                if (usuario == null)
                    return new ReadUsuarioDto();

                return _mapper.Map<ReadUsuarioDto>(usuario);
            }
            catch (Exception)
            {
                return new ReadUsuarioDto();
            }
        }
    }
}

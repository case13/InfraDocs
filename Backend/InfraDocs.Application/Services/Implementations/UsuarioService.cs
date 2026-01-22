using AutoMapper;
using AutoMapper.QueryableExtensions;
using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Domain.Entities;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Shared.Dtos.Common;
using InfraDocs.Shared.Dtos.Usuario;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PagedResultDto<ReadUsuarioDto>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string? filterColumn,
            string? filterText)
        {
            var query = _repository.Query(asNoTracking: true);
            if(!string.IsNullOrWhiteSpace(filterColumn) &&
                !string.IsNullOrWhiteSpace(filterText))
            {
                filterText = filterText.Trim().ToLower();
                query = filterColumn.ToLower() switch
                {
                    "nome" => query.Where(x => x.Nome.ToLower().Contains(filterText)),
                    "email" => query.Where(x => x.Email.ToLower().Contains(filterText)),
                    _ => query
                };
            }
            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(p => p.Nome) // ou p.Id, como preferir
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ReadUsuarioDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResultDto<ReadUsuarioDto>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

    }
}

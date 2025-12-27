using InfraDocs.Shared.Dtos.Pessoa;

namespace InfraDocs.Application.Services.Interfaces
{
    public interface IPessoaService
        : IBaseService<
            ReadPessoaDto,
            CreatePessoaDto,
            UpdatePessoaDto>
    {
        Task<ReadPessoaDto> GetByDocumentoAsync(string documento);
    }
}

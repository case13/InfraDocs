using InfraDocs.BlazorServer.Services.Interfaces;
using InfraDocs.BlazorServer.ViewModels.Interfaces;
using InfraDocs.Shared.Dtos.Usuario;

namespace InfraDocs.BlazorServer.ViewModels.Implementations
{
    public class UsuarioViewModel : IUsuarioViewModel
    {
        private readonly IUsuarioApiService _service;

        public bool IsBusy { get; private set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; private set; }

        public string? SelectedColumn { get; set; } = "Nome";
        public string SearchTerm { get; set; } = string.Empty;

        public IEnumerable<ReadUsuarioDto> Usuarios { get; private set; }
            = Enumerable.Empty<ReadUsuarioDto>();

        public ReadUsuarioDto? Selecionado { get; set; }

        public CreateUsuarioDto Novo { get; set; } = new();
        public UpdateUsuarioDto Edicao { get; set; } = new();

        public UsuarioViewModel(IUsuarioApiService service)
        {
            _service = service;
        }

        public async Task CarregarPaginadoAsync()
        {
            IsBusy = true;
            try
            {
                var term = string.IsNullOrWhiteSpace(SearchTerm)
                    ? null
                    : SearchTerm;

                var page = await _service.ObterPaginadoAsync(
                    PageNumber,
                    PageSize,
                    SelectedColumn,
                    term);

                Usuarios = page?.Items?.ToList()
                    ?? Enumerable.Empty<ReadUsuarioDto>();

                TotalCount = page?.TotalCount ?? 0;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task CarregarPorIdAsync(int id)
        {
            IsBusy = true;
            try
            {
                var dto = await _service.ObterPorIdAsync(id);
                Selecionado = dto;

                if (dto is not null)
                {
                    Edicao = new UpdateUsuarioDto
                    {
                        Nome = dto.Nome,
                        Email = dto.Email,
                        TipoDocumento = dto.TipoDocumento,
                        TipoUsuario = dto.TipoUsuario,
                        StatusUsuario = dto.StatusUsuario
                    };
                }
                else
                {
                    Edicao = new UpdateUsuarioDto();
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> CriarAsync()
        {
            IsBusy = true;
            try
            {
                var ok = await _service.IncluirAsync(Novo);
                if (ok)
                    await CarregarPaginadoAsync();

                return ok;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> SalvarEdicaoAsync()
        {
            if (Selecionado is null)
                return false;

            IsBusy = true;
            try
            {
                var ok = await _service.EditarAsync(
                    Selecionado.Id,
                    Edicao);

                if (ok)
                    await CarregarPaginadoAsync();

                return ok;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            IsBusy = true;
            try
            {
                var ok = await _service.ExcluirAsync(id);
                if (ok)
                {
                    await CarregarPaginadoAsync();

                    if (!Usuarios.Any() && PageNumber > 1)
                    {
                        PageNumber--;
                        await CarregarPaginadoAsync();
                    }
                }

                return ok;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void DefinirPagina(int pageNumber)
        {
            PageNumber = pageNumber <= 0 ? 1 : pageNumber;
        }
    }
}

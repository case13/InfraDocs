using InfraDocs.Shared.Dtos.Usuario;

namespace InfraDocs.BlazorServer.ViewModels.Interfaces
{
    public interface IUsuarioViewModel
    {
        bool IsBusy { get; }

        int PageNumber { get; set; }
        int PageSize { get; set; }
        int TotalCount { get; }

        string? SelectedColumn { get; set; }
        string SearchTerm { get; set; }

        IEnumerable<ReadUsuarioDto> Usuarios { get; }
        ReadUsuarioDto? Selecionado { get; set; }

        CreateUsuarioDto Novo { get; set; }
        UpdateUsuarioDto Edicao { get; set; }

        Task CarregarPaginadoAsync();
        Task CarregarPorIdAsync(int id);

        Task<bool> CriarAsync();
        Task<bool> SalvarEdicaoAsync();
        Task<bool> ExcluirAsync(int id);

        void DefinirPagina(int pageNumber);
    }
}

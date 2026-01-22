using InfraDocs.BlazorServer.Services.Interfaces;
using InfraDocs.Shared.Dtos.Common;
using InfraDocs.Shared.Dtos.Usuario;
using System.Net.Http.Json;

namespace InfraDocs.BlazorServer.Services.Implementations
{
    public class UsuarioApiService : ApiServiceBase, IUsuarioApiService
    {
        public UsuarioApiService(
            IHttpClientFactory httpFactory,
            AuthService authService) : base(httpFactory.CreateClient("ApiAuth"), authService)
        {
            
        }

        public async Task<PagedResultDto<ReadUsuarioDto>> ObterPaginadoAsync(
            int pageNumber,
            int pageSize,
            string? colunaOrdenacao,
            string? termoBusca,
            CancellationToken ct = default)
        {
            await EnsureAuthHeaderAsync();

            var qs = new List<string>
            {
                $"page={pageNumber}",
                $"pageSize={pageSize}"
            };

            if (!string.IsNullOrWhiteSpace(colunaOrdenacao) &&
                !string.IsNullOrWhiteSpace(termoBusca))
            {
                qs.Add($"filterColumn={Uri.EscapeDataString(colunaOrdenacao)}");
                qs.Add($"filterText={Uri.EscapeDataString(termoBusca)}");
            }

            var url = $"api/usuario/paginado?{string.Join("&", qs)}";
            using var resp = await Http.GetAsync(url, ct);

            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync(ct);
                Console.WriteLine(
                    $"[UsuarioApiService] GET paginado -> {(int)resp.StatusCode} {resp.ReasonPhrase} - {body}");

                return new PagedResultDto<ReadUsuarioDto>
                {
                    Items = new List<ReadUsuarioDto>(),
                    TotalCount = 0
                };
            }

            return await resp.Content.ReadFromJsonAsync<PagedResultDto<ReadUsuarioDto>>(cancellationToken: ct)
                   ?? new PagedResultDto<ReadUsuarioDto>
                   {
                       Items = new List<ReadUsuarioDto>(),
                       TotalCount = 0
                   };
        }

        public async Task<IEnumerable<ReadUsuarioDto>> ObterTodosAsync()
        {
            await EnsureAuthHeaderAsync();

            using var resp = await Http.GetAsync("api/usuario");

            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync();
                Console.WriteLine(
                    $"[UsuarioApiService] GET todos -> {(int)resp.StatusCode} {resp.ReasonPhrase} - {body}");

                return Enumerable.Empty<ReadUsuarioDto>();
            }

            return await resp.Content.ReadFromJsonAsync<List<ReadUsuarioDto>>()
                   ?? Enumerable.Empty<ReadUsuarioDto>();
        }

        public async Task<ReadUsuarioDto> ObterPorIdAsync(int id)
        {
            await EnsureAuthHeaderAsync();

            using var resp = await Http.GetAsync($"api/usuario/{id}");

            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync();
                Console.WriteLine(
                    $"[UsuarioApiService] GET por id -> {(int)resp.StatusCode} {resp.ReasonPhrase} - {body}");

                return new ReadUsuarioDto();
            }

            return await resp.Content.ReadFromJsonAsync<ReadUsuarioDto>()
                   ?? new ReadUsuarioDto();
        }

        public async Task<bool> IncluirAsync(CreateUsuarioDto dto)
        {
            await EnsureAuthHeaderAsync();

            using var resp = await Http.PostAsJsonAsync("api/usuario", dto);

            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync();
                Console.WriteLine(
                    $"[UsuarioApiService] POST -> {(int)resp.StatusCode} {resp.ReasonPhrase} - {body}");

                return false;
            }

            return true;
        }

        public async Task<bool> EditarAsync(int id, UpdateUsuarioDto dto)
        {
            await EnsureAuthHeaderAsync();

            using var resp = await Http.PutAsJsonAsync($"api/usuario/{id}", dto);

            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync();
                Console.WriteLine(
                    $"[UsuarioApiService] PUT -> {(int)resp.StatusCode} {resp.ReasonPhrase} - {body}");

                return false;
            }

            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            await EnsureAuthHeaderAsync();

            using var resp = await Http.DeleteAsync($"api/usuario/{id}");

            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync();
                Console.WriteLine(
                    $"[UsuarioApiService] DELETE -> {(int)resp.StatusCode} {resp.ReasonPhrase} - {body}");

                return false;
            }

            return true;
        }
    }
}

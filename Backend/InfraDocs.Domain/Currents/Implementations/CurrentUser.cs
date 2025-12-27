using InfraDocs.Domain.Currents.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InfraDocs.Infrastructure.Current.Implementations
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UsuarioId
        {
            get
            {
                var raw = _httpContextAccessor.HttpContext?
                    .User?
                    .FindFirstValue(ClaimTypes.NameIdentifier);

                return int.TryParse(raw, out var id) ? id : null;
            }
        }

        public string? Email =>
            _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.Email);

        public string? Nome =>
            _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.Name);

        public string? TipoUsuario =>
            _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue("tipo_usuario");
    }
}

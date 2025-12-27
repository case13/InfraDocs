using InfraDocs.Domain.Currents.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InfraDocs.Infrastructure.Current.Implementations
{
    public class CurrentOrganizacao : ICurrentOrganizacao
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentOrganizacao(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? OrganizacaoId
        {
            get
            {
                var raw = _httpContextAccessor.HttpContext?
                    .User?
                    .FindFirstValue("organizacao_id");

                return int.TryParse(raw, out var id) ? id : null;
            }
        }
    }
}

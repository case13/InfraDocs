using Microsoft.AspNetCore.Authorization;
using InfraDocs.Shared.Enums;

namespace InfraDocs.Api.Authorization.Requirements
{
    public class TipoUsuarioRequirement : IAuthorizationRequirement
    {
        public IReadOnlyCollection<TipoUsuarioEnum> TiposPermitidos { get; }

        public TipoUsuarioRequirement(params TipoUsuarioEnum[] tiposPermitidos)
        {
            TiposPermitidos = tiposPermitidos;
        }
    }
}

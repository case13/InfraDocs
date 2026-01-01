using InfraDocs.Api.Authorization.Requirements;
using InfraDocs.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InfraDocs.Api.Authorization.Handlers
{
    public class SomenteLeituraHandler
        : AuthorizationHandler<SomenteLeituraRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            SomenteLeituraRequirement requirement)
        {
            if (!context.User.Identity?.IsAuthenticated ?? true)
                return Task.CompletedTask;

            var tipoUsuarioClaim =
                context.User.FindFirst("tipo_usuario")?.Value;

            if (!Enum.TryParse<TipoUsuarioEnum>(tipoUsuarioClaim, out var tipoUsuario))
                return Task.CompletedTask;

            // Todos podem ler
            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

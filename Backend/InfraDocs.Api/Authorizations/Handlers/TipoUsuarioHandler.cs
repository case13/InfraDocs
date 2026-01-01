using Microsoft.AspNetCore.Authorization;
using InfraDocs.Api.Authorization.Requirements;
using InfraDocs.Shared.Enums;

namespace InfraDocs.Api.Authorization.Handlers
{
    public class TipoUsuarioHandler : AuthorizationHandler<TipoUsuarioRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            TipoUsuarioRequirement requirement)
        {
            var claim = context.User.FindFirst("tipo_usuario");

            if (claim == null)
                return Task.CompletedTask;

            if (!Enum.TryParse<TipoUsuarioEnum>(claim.Value, out var tipoUsuario))
                return Task.CompletedTask;

            if (requirement.TiposPermitidos.Contains(tipoUsuario))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

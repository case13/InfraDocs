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
            Console.WriteLine("=== TipoUsuarioHandler EXECUTOU ===");
            Console.WriteLine("IsAuthenticated: " + context.User.Identity?.IsAuthenticated);

            foreach (var claim in context.User.Claims)
            {
                Console.WriteLine($"CLAIM => {claim.Type} = {claim.Value}");
            }

            var claimTipo = context.User.FindFirst("tipo_usuario");

            if (claimTipo == null)
            {
                Console.WriteLine("❌ CLAIM tipo_usuario NÃO EXISTE");
                return Task.CompletedTask;
            }

            Console.WriteLine("tipo_usuario recebido: " + claimTipo.Value);

            if (!Enum.TryParse<TipoUsuarioEnum>(claimTipo.Value, out var tipoUsuario))
            {
                Console.WriteLine("❌ NÃO conseguiu converter para enum");
                return Task.CompletedTask;
            }

            Console.WriteLine("Enum convertido: " + tipoUsuario);

            if (requirement.TiposPermitidos.Contains(tipoUsuario))
            {
                Console.WriteLine("✅ POLICY SATISFEITA");
                context.Succeed(requirement);
            }
            else
            {
                Console.WriteLine("❌ POLICY NÃO SATISFEITA");
            }

            return Task.CompletedTask;
        }
    }
}

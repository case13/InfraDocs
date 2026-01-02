using InfraDocs.Shared.Authorizations;
using InfraDocs.Shared.Enums;
using Microsoft.AspNetCore.Authorization;

namespace InfraDocs.BlazorServer.Configurations
{
    public static class AuthorizationDependencyInjection
    {
        public static IServiceCollection AddAuthorizationConfiguration(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyNames.Administrador, policy =>
                    policy.RequireClaim("tipo_usuario", TipoUsuarioEnum.Administrador.ToString()));

                options.AddPolicy(PolicyNames.AdminOuUsuario, policy =>
                    policy.RequireClaim("tipo_usuario",
                        TipoUsuarioEnum.Administrador.ToString(),
                        TipoUsuarioEnum.UsuarioComum.ToString()));

                options.AddPolicy(PolicyNames.SomenteLeitura, policy =>
                    policy.RequireClaim("tipo_usuario", TipoUsuarioEnum.Convidado.ToString()));
            });

            return services;
        }
    }
}

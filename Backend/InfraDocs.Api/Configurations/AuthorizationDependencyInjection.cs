using InfraDocs.Api.Authorization.Handlers;
using InfraDocs.Shared.Authorizations;
using InfraDocs.Api.Authorization.Requirements;
using InfraDocs.Shared.Enums;
using Microsoft.AspNetCore.Authorization;

namespace InfraDocs.Api.Configurations
{
    public static class AuthorizationDependencyInjection
    {
        public static IServiceCollection AddAuthorizationConfiguration(
            this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                // Somente Administrador
                options.AddPolicy(PolicyNames.Administrador, policy =>
                    policy.Requirements.Add(
                        new TipoUsuarioRequirement(
                            TipoUsuarioEnum.Administrador)));

                // Administrador ou Usuário Comum
                options.AddPolicy(PolicyNames.AdminOuUsuario, policy =>
                    policy.Requirements.Add(
                        new TipoUsuarioRequirement(
                            TipoUsuarioEnum.Administrador,
                            TipoUsuarioEnum.UsuarioComum)));

                // Usuário Comum (Administrador também passa)
                options.AddPolicy(PolicyNames.UsuarioComum, policy =>
                    policy.Requirements.Add(
                        new TipoUsuarioRequirement(
                            TipoUsuarioEnum.UsuarioComum,
                            TipoUsuarioEnum.Administrador)));

                // Somente Leitura 
                options.AddPolicy(PolicyNames.SomenteLeitura, policy =>
                    policy.Requirements.Add(new SomenteLeituraRequirement()));
            });

            // Handler das policies
            services.AddScoped<IAuthorizationHandler, TipoUsuarioHandler>();
            services.AddScoped<IAuthorizationHandler, SomenteLeituraHandler>();

            return services;
        }
    }
}

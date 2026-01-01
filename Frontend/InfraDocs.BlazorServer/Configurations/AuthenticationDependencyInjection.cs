using InfraDocs.BlazorServer.Pages;
using InfraDocs.BlazorServer.Authentications;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.DependencyInjection;

namespace InfraDocs.Frontend.Configurations
{
    public static class AuthenticationDependencyInjection
    {
        public static IServiceCollection AddAuthenticationConfiguration(
            this IServiceCollection services)
        {
            services.AddAuthorizationCore();

            services.AddScoped<ProtectedSessionStorage>();

            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            return services;
        }
    }
}

using InfraDocs.BlazorServer.Authentications;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace InfraDocs.Frontend.Configurations
{
    public static class AuthenticationDependencyInjection
    {
        public static IServiceCollection AddAuthenticationConfiguration(
            this IServiceCollection services)
        {
            services.AddAuthorizationCore();

            services.AddScoped<ProtectedSessionStorage>();

            services.AddScoped<AuthStateProvider>();

            services.AddScoped<AuthenticationStateProvider>(
                sp => sp.GetRequiredService<AuthStateProvider>());

            return services;
        }
    }
}

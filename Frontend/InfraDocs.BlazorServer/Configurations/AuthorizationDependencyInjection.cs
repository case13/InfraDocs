using Microsoft.Extensions.DependencyInjection;

namespace InfraDocs.BlazorServer.Configurations
{
    public static class AuthorizationDependencyInjection
    {
        public static IServiceCollection AddAuthorizationConfiguration(
            this IServiceCollection services)
        {
            services.AddAuthorizationCore();

            return services;
        }
    }
}

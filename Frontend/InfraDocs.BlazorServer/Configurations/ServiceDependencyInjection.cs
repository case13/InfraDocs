using InfraDocs.BlazorServer.Services;
using InfraDocs.BlazorServer.Services.Implementations;
using InfraDocs.BlazorServer.Services.Interfaces;
using InfraDocs.BlazorServer.ViewModels.Implementations;
using InfraDocs.BlazorServer.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InfraDocs.BlazorServer.Configurations
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddFrontendServices(
            this IServiceCollection services)
        {
            services.AddScoped<AuthService>();
            services.AddScoped<IUsuarioApiService, UsuarioApiService>();
            //services.AddScoped<OrganizacaoApiService>();
            // futuros services aqui

            services.AddScoped<IUsuarioViewModel, UsuarioViewModel>();

            return services;
        }
    }
}

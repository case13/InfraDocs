using InfraDocs.BlazorServer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfraDocs.BlazorServer.Configurations
{
    public static class HttpClientDependencyInjection
    {
        public static IServiceCollection AddHttpClientConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHttpClient<ApiHttpClient>(client =>
            {
                client.BaseAddress = new Uri(
                    configuration["ApiSettings:BaseUrl"]!
                );
            });

            services.AddScoped(sp =>
                sp.GetRequiredService<ApiHttpClient>().HttpClient
            );

            return services;
        }
    }
}

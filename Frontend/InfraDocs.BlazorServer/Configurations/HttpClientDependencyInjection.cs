using Microsoft.Extensions.DependencyInjection;

namespace InfraDocs.BlazorServer.Configurations
{
    public static class HttpClientDependencyInjection
    {
        public static IServiceCollection AddApiHttpClient(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(sp =>
            {
                var apiBaseUrl = configuration["ApiSettings:BaseUrl"];

                return new HttpClient
                {
                    BaseAddress = new Uri(apiBaseUrl!)
                };
            });

            return services;
        }
    }
}


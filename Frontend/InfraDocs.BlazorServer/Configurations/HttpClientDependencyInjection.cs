namespace InfraDocs.BlazorServer.Configurations
{
    public static class HttpClientDependencyInjection
    {
        public static IServiceCollection AddApiHttpClient(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // 🔓 LOGIN / REFRESH (SEM TOKEN)
            services.AddHttpClient("Api", client =>
            {
                client.BaseAddress =
                    new Uri(configuration["ApiSettings:BaseUrl"]!);
            });

            // 🔐 API AUTENTICADA (COM TOKEN)
            services.AddHttpClient("ApiAuth", client =>
            {
                client.BaseAddress =
                    new Uri(configuration["ApiSettings:BaseUrl"]!);
            });

            return services;
        }
    }
}

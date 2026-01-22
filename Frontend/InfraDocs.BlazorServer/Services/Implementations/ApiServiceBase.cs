using System.Net.Http.Headers;

namespace InfraDocs.BlazorServer.Services.Implementations
{
    public abstract class ApiServiceBase
    {
        protected readonly HttpClient Http;
        protected readonly AuthService Auth;

        protected ApiServiceBase(HttpClient http, AuthService auth)
        {
            Http = http;
            Auth = auth;
        }

        protected async Task EnsureAuthHeaderAsync()
        {
            var token = await Auth.GetTokenAsync();

            Console.WriteLine($"[EnsureAuthHeaderAsync] Token: {token}");

            if (string.IsNullOrWhiteSpace(token))
                return;

            if (Http.DefaultRequestHeaders.Authorization?.Parameter == token)
                return;

            Http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}

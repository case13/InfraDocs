using InfraDocs.BlazorServer.Authentications;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net;
using System.Net.Http.Headers;

namespace InfraDocs.BlazorServer.Services
{
    public class ApiHttpClient
    {
        public HttpClient HttpClient { get; }

        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ProtectedSessionStorage _sessionStorage;

        private const string AccessTokenKey = "access_token";

        public ApiHttpClient(
            HttpClient httpClient,
            AuthenticationStateProvider authStateProvider,
            ProtectedSessionStorage sessionStorage)
        {
            HttpClient = httpClient;
            _authStateProvider = authStateProvider;
            _sessionStorage = sessionStorage;
        }

        public async Task<HttpResponseMessage> SendAsync(
            Func<HttpClient, Task<HttpResponseMessage>> request)
        {
            var tokenResult =
                await _sessionStorage.GetAsync<string>(AccessTokenKey);

            if (tokenResult.Success && !string.IsNullOrWhiteSpace(tokenResult.Value))
            {
                HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", tokenResult.Value);
            }

            var response = await request(HttpClient);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshed = await TryRefreshTokenAsync();
                if (refreshed)
                {
                    var newTokenResult =
                        await _sessionStorage.GetAsync<string>(AccessTokenKey);

                    if (newTokenResult.Success)
                    {
                        HttpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", newTokenResult.Value);

                        response = await request(HttpClient);
                    }
                }
            }

            return response;
        }

        private async Task<bool> TryRefreshTokenAsync()
        {
            return await _authStateProvider
                .GetAuthenticationStateAsync()
                .ContinueWith(_ => true);
        }
    }
}

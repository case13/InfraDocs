using InfraDocs.BlazorServer.Authentications;
using InfraDocs.Shared.Dtos.Auth;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Json;

namespace InfraDocs.BlazorServer.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly AuthStateProvider _authStateProvider;
        private readonly ProtectedSessionStorage _sessionStorage;

        private const string RefreshTokenKey = "refresh_token";

        public AuthService(
            HttpClient http,
            AuthStateProvider authStateProvider,
            ProtectedSessionStorage sessionStorage)
        {
            _http = http;
            _authStateProvider = authStateProvider;
            _sessionStorage = sessionStorage;
        }

        public async Task<bool> LoginAsync(string email)
        {
            var response = await _http.PostAsJsonAsync(
                "/api/auth/login",
                email);

            if (!response.IsSuccessStatusCode)
                return false;

            var result =
                await response.Content.ReadFromJsonAsync<LoginResultDto>();

            if (result == null || string.IsNullOrWhiteSpace(result.AccessToken))
                return false;

            // refresh token
            await _sessionStorage.SetAsync(RefreshTokenKey, result.RefreshToken);

            // atualiza o estado global de auth
            await _authStateProvider.SetLoginAsync(result.AccessToken);

            return true;
        }

        public async Task<bool> RefreshTokenAsync()
        {
            var refreshTokenResult =
                await _sessionStorage.GetAsync<string>(RefreshTokenKey);

            if (!refreshTokenResult.Success ||
                string.IsNullOrWhiteSpace(refreshTokenResult.Value))
                return false;

            var dto = new RefreshTokenDto
            {
                RefreshToken = refreshTokenResult.Value
            };

            var response = await _http.PostAsJsonAsync(
                "/api/auth/refresh",
                dto);

            if (!response.IsSuccessStatusCode)
                return false;

            var result =
                await response.Content.ReadFromJsonAsync<LoginResultDto>();

            if (result == null || string.IsNullOrWhiteSpace(result.AccessToken))
                return false;

            await _sessionStorage.SetAsync(RefreshTokenKey, result.RefreshToken);
            await _authStateProvider.SetLoginAsync(result.AccessToken);

            return true;
        }

        public async Task LogoutAsync()
        {
            await _sessionStorage.DeleteAsync(RefreshTokenKey);
            await _authStateProvider.LogoutAsync();
        }
    }
}

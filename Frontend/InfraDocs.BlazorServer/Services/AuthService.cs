using InfraDocs.Shared.Dtos.Auth;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Json;

namespace InfraDocs.BlazorServer.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly ProtectedSessionStorage _storage;

        private string? _cachedToken;

        private const string AccessTokenKey = "access_token";
        private const string RefreshTokenKey = "refresh_token";

        public AuthService(
            IHttpClientFactory factory,
            ProtectedSessionStorage storage)
        {
            _http = factory.CreateClient("Api"); 
            _storage = storage;
        }

        public async Task<string?> GetTokenAsync()
        {
            if (!string.IsNullOrWhiteSpace(_cachedToken))
                return _cachedToken;

            var result = await _storage.GetAsync<string>(AccessTokenKey);
            _cachedToken = result.Success ? result.Value : null;
            return _cachedToken;
        }

        public async Task<bool> LoginAsync(string email)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/login", email);
            if (!response.IsSuccessStatusCode)
                return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResultDto>();
            if (string.IsNullOrWhiteSpace(result?.AccessToken))
                return false;

            _cachedToken = result.AccessToken;

            await _storage.SetAsync(AccessTokenKey, result.AccessToken);
            await _storage.SetAsync(RefreshTokenKey, result.RefreshToken);

            return true;
        }

        public async Task ClearAsync()
        {
            _cachedToken = null;
            await _storage.DeleteAsync(AccessTokenKey);
            await _storage.DeleteAsync(RefreshTokenKey);
        }
    }
}

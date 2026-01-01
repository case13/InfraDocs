using InfraDocs.BlazorServer.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace InfraDocs.BlazorServer.Authentications
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous =
            new ClaimsPrincipal(new ClaimsIdentity());

        private bool _initialized;

        private const string AccessTokenKey = "access_token";

        public AuthStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // DURANTE PRERENDER → sempre anônimo
            if (!_initialized)
                return Task.FromResult(new AuthenticationState(_anonymous));

            return GetAuthStateInternalAsync();
        }

        private async Task<AuthenticationState> GetAuthStateInternalAsync()
        {
            var tokenResult =
                await _sessionStorage.GetAsync<string>(AccessTokenKey);

            if (!tokenResult.Success || string.IsNullOrWhiteSpace(tokenResult.Value))
                return new AuthenticationState(_anonymous);

            var claims = JwtParser.ParseClaimsFromJwt(tokenResult.Value);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        public async Task SetLoginAsync(string accessToken)
        {
            await _sessionStorage.SetAsync(AccessTokenKey, accessToken);
            _initialized = true;

            NotifyAuthenticationStateChanged(GetAuthStateInternalAsync());
        }

        public async Task LogoutAsync()
        {
            await _sessionStorage.DeleteAsync(AccessTokenKey);
            _initialized = true;

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(_anonymous)));
        }

        // CHAMAR NO OnAfterRenderAsync
        public async Task InitializeAsync()
        {
            _initialized = true;
            NotifyAuthenticationStateChanged(GetAuthStateInternalAsync());
        }
    }
}

using InfraDocs.BlazorServer.Utils;
using InfraDocs.Shared.Dtos.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace InfraDocs.BlazorServer.Authentications
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        private const string AccessTokenKey = "access_token";

        public AuthStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenResult = await _sessionStorage.GetAsync<string>(AccessTokenKey);

            if (!tokenResult.Success || string.IsNullOrWhiteSpace(tokenResult.Value))
            {
                return new AuthenticationState(
                    new ClaimsPrincipal(new ClaimsIdentity())
                );
            }

            var claims = JwtParser.ParseClaimsFromJwt(tokenResult.Value);

            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        public async Task SetLoginAsync(string accessToken)
        {
            await _sessionStorage.SetAsync(AccessTokenKey, accessToken);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task LogoutAsync()
        {
            await _sessionStorage.DeleteAsync(AccessTokenKey);

            NotifyAuthenticationStateChanged(
                Task.FromResult(
                    new AuthenticationState(
                        new ClaimsPrincipal(new ClaimsIdentity())
                    )
                )
            );
        }
    }
}

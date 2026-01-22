using InfraDocs.BlazorServer.Authentications;
using System.Net.Http.Headers;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly ITokenStore _tokenStore;

    public AuthHeaderHandler(ITokenStore tokenStore)
    {
        _tokenStore = tokenStore;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        Console.WriteLine($"[AuthService] TokenStore hash: {_tokenStore.GetHashCode()}");
        if (!string.IsNullOrWhiteSpace(_tokenStore.AccessToken))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _tokenStore.AccessToken);
            Console.WriteLine($"[AuthHeaderHandler] Authorization header INJETADO - Token:{_tokenStore.AccessToken}");
        }
        else
        {
            Console.WriteLine("[AuthHeaderHandler] TOKEN NULL");
        }

        return base.SendAsync(request, cancellationToken);
    }
}

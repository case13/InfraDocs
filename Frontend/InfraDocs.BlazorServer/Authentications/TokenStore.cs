namespace InfraDocs.BlazorServer.Authentications
{
    public class TokenStore : ITokenStore
    {
        public string? AccessToken { get; private set; }

        public void Set(string token)
        {
            AccessToken = token;
        }

        public void Clear()
        {
            AccessToken = null;
        }
    }
}

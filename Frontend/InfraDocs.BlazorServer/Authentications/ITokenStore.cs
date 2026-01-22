namespace InfraDocs.BlazorServer.Authentications
{
    public interface ITokenStore
    {
        string? AccessToken { get; }
        void Set(string token);
        void Clear();
    }
}

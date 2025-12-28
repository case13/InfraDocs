using InfraDocs.Domain.Entities;

namespace InfraDocs.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(Usuario usuario);
        RefreshToken GenerateRefreshToken();
    }
}

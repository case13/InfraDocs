using InfraDocs.Shared.Dtos.Auth;
using InfraDocs.Shared.Dtos.Usuario;

namespace InfraDocs.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResultDto> LoginAsync(string email);
        Task<LoginResultDto> RefreshAsync(string refreshToken);
    }
}

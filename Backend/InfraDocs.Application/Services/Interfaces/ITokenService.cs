using InfraDocs.Domain.Entities;

namespace InfraDocs.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}

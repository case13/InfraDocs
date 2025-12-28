using InfraDocs.Domain.Entities;

namespace InfraDocs.Domain.Repositories.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task SaveChangesAsync();
    }
}

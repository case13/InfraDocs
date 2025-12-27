using System;

namespace InfraDocs.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public string Token { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
        public DateTime? RevokedAt { get; set; }

        // Propriedades de domínio (não mapeadas)
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
        public bool IsRevoked => RevokedAt != null;
        public bool IsValid => !IsExpired && !IsRevoked;
    }
}

using InfraDocs.Shared.Enums;

namespace InfraDocs.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public int OrganizacaoId { get; set; }
        public Organizacao Organizacao { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public TipoDocumentoEnum TipoDocumento { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public StatusBasicoEnum StatusUsuario { get; set; }
    }
}

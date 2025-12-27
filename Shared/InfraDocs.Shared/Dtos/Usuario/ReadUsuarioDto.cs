using InfraDocs.Shared.Enums;

namespace InfraDocs.Shared.Dtos.Usuario
{
    public class ReadUsuarioDto
    {
        public int Id { get; set; }
        public int OrganizacaoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public TipoDocumentoEnum TipoDocumento { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public StatusBasicoEnum StatusUsuario { get; set; }
    }
}

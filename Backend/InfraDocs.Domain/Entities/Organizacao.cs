using InfraDocs.Shared.Enums;

namespace InfraDocs.Domain.Entities
{
    public class Organizacao : BaseEntity
    {
        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public TipoDocumentoEnum TipoDocumento { get; set; }
        public StatusBasicoEnum StatusOrganizacao { get; set; }
    }
}

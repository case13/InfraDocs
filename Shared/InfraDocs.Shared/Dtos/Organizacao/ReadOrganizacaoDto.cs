using InfraDocs.Shared.Enums;

namespace InfraDocs.Shared.Dtos.Organizacao
{
    public class ReadOrganizacaoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Documento { get; set; } = string.Empty;

        public TipoDocumentoEnum TipoDocumento { get; set; }

        public StatusBasicoEnum StatusOrganizacao { get; set; }

        public bool IsActive { get; set; }
    }
}

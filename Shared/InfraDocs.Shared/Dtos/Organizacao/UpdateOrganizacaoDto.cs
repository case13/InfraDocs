using InfraDocs.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace InfraDocs.Shared.Dtos.Organizacao
{
    public class UpdateOrganizacaoDto
    {
        [Required(ErrorMessage = "O ID da organização é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da organização é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O documento da organização é obrigatório.")]
        public string Documento { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de documento é obrigatório.")]
        public TipoDocumentoEnum TipoDocumento { get; set; }

        [Required(ErrorMessage = "O status da organização é obrigatório.")]
        public StatusBasicoEnum StatusOrganizacao { get; set; }
    }
}

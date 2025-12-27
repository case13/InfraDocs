using InfraDocs.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace InfraDocs.Shared.Dtos.Usuario
{
    public class UpdateUsuarioDto
    {
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail do usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O documento do usuário é obrigatório.")]
        public string Documento { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de documento é obrigatório.")]
        public TipoDocumentoEnum TipoDocumento { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        public TipoUsuarioEnum TipoUsuario { get; set; }

        [Required(ErrorMessage = "O status do usuário é obrigatório.")]
        public StatusBasicoEnum StatusUsuario { get; set; }
        
    }
}

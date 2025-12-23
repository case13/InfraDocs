using InfraDocs.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace InfraDocs.Shared.Dtos.Pessoa
{
    public class CreatePessoaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O documento é obrigatório")]
        public string Documento { get; set; } = null!;

        [Required(ErrorMessage = "O tipo de documento é obrigatório")]
        public TipoDocumentoEnum TipoDocumento { get; set; }

        public string? Rg { get; set; }
        public string? OrgaoEmissor { get; set; }
        public string? Profissao { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        public string Email { get; set; } = null!;

        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório")]
        public string Logradouro { get; set; } = null!;

        [Required(ErrorMessage = "O número é obrigatório")]
        public string Numero { get; set; } = null!;

        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; } = null!;

        [Required(ErrorMessage = "O CEP é obrigatório")]
        public string Cep { get; set; } = null!;

        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; } = null!;

        [Required(ErrorMessage = "A UF é obrigatória")]
        public string Uf { get; set; } = null!;
    }
}

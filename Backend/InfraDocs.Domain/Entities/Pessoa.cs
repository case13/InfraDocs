using InfraDocs.Shared.Enums;

namespace InfraDocs.Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public int OrganizacaoId { get; set; }
        public Organizacao Organizacao { get; set; } = null!;

        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public TipoDocumentoEnum TipoDocumento { get; set; }

        public string? Rg { get; set; }
        public string? OrgaoEmissor { get; set; }

        public string? Profissao { get; set; }

        // Contato
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        // Endereço (embutido)
        public string Logradouro { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Uf { get; set; } = null!;

        public StatusBasicoEnum StatusPessoa { get; set; }
    }
}

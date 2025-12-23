using InfraDocs.Shared.Enums;

namespace InfraDocs.Shared.Dtos.Pessoa
{
    public class ReadPessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public TipoDocumentoEnum TipoDocumento { get; set; }
        public string? Rg { get; set; }
        public string? OrgaoEmissor { get; set; }
        public string? Profissao { get; set; }
        public string Email { get; set; } = null!;
        public string? Telefone { get; set; }
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

using InfraDocs.Shared.Dtos.Pessoa;
using InfraDocs.Shared.Enums;
using System;

namespace InfraDocs.Shared.Dtos.RequerimentoSuspensaoRestricao
{
    public class ReadRequerimentoSuspensaoRestricaoDto
    {
        public int Id { get; set; }
        public string NumeroProtocolo { get; set; } = null!;
        public StatusRequerimentoEnum StatusRequerimento { get; set; }
        public TipoRequerimentoEnum TipoRequerimento { get; set; }
        public ReadPessoaDto Pessoa { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public DateTime DataDocumento { get; set; }
        public string PlacaVeiculo { get; set; } = null!;
        public string UfVeiculo { get; set; } = null!;
        public string MarcaModeloVeiculo { get; set; } = null!;
        public string CidadeOcorrencia { get; set; } = null!;
        public string UfOcorrencia { get; set; } = null!;
        public string Justificativa { get; set; } = null!;
        public string CidadeAssinatura { get; set; } = null!;
        public string UfAssinatura { get; set; } = null!;
        public DateTime DataAssinatura { get; set; }
        public string NomeAssinante { get; set; } = null!;
    }
}

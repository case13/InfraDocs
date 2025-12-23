using InfraDocs.Shared.Enums;
using System;

namespace InfraDocs.Domain.Entities
{
    public class RequerimentoSuspensaoRestricao : BaseEntity
    {
        // Controle / Sistema
        public int OrganizacaoId { get; set; }
        public Organizacao Organizacao { get; set; } = null!;

        public string NumeroProtocolo { get; set; } = null!;
        public StatusRequerimentoEnum StatusRequerimento { get; set; }

        // Tipo do Requerimento
        public TipoRequerimentoEnum TipoRequerimento { get; set; }

        // Requerente (Pessoa)
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; } = null!;

        // Dados do Documento (RRD / DLC)
        public string NumeroDocumento { get; set; } = null!;
        public DateTime DataDocumento { get; set; }

        // Dados do Veículo (snapshot)
        public string PlacaVeiculo { get; set; } = null!;
        public string UfVeiculo { get; set; } = null!;
        public string MarcaModeloVeiculo { get; set; } = null!;

        // Local da Ocorrência
        public string? Br { get; set; }
        public string? Km { get; set; }
        public string CidadeOcorrencia { get; set; } = null!;
        public string UfOcorrencia { get; set; } = null!;
        public string? LocalReferencia { get; set; }

        // Solicitação / Justificativa
        public string Justificativa { get; set; } = null!;

        // Assinatura
        public string CidadeAssinatura { get; set; } = null!;
        public string UfAssinatura { get; set; } = null!;
        public DateTime DataAssinatura { get; set; }
        public string NomeAssinante { get; set; } = null!;
    }
}

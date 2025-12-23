using InfraDocs.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace InfraDocs.Shared.Dtos.RequerimentoSuspensaoRestricao
{
    public class CreateRequerimentoSuspensaoRestricaoDto
    {
        [Required(ErrorMessage = "O tipo de requerimento é obrigatório")]
        public TipoRequerimentoEnum TipoRequerimento { get; set; }

        [Required(ErrorMessage = "O requerente é obrigatório")]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "O número do documento é obrigatório")]
        public string NumeroDocumento { get; set; } = null!;

        [Required(ErrorMessage = "A data do documento é obrigatória")]
        public DateTime DataDocumento { get; set; }

        [Required(ErrorMessage = "A placa do veículo é obrigatória")]
        public string PlacaVeiculo { get; set; } = null!;

        [Required(ErrorMessage = "A UF do veículo é obrigatória")]
        public string UfVeiculo { get; set; } = null!;

        [Required(ErrorMessage = "A marca/modelo do veículo é obrigatória")]
        public string MarcaModeloVeiculo { get; set; } = null!;

        [Required(ErrorMessage = "A cidade da ocorrência é obrigatória")]
        public string CidadeOcorrencia { get; set; } = null!;

        [Required(ErrorMessage = "A UF da ocorrência é obrigatória")]
        public string UfOcorrencia { get; set; } = null!;

        [Required(ErrorMessage = "A justificativa é obrigatória")]
        public string Justificativa { get; set; } = null!;

        [Required(ErrorMessage = "A cidade da assinatura é obrigatória")]
        public string CidadeAssinatura { get; set; } = null!;

        [Required(ErrorMessage = "A UF da assinatura é obrigatória")]
        public string UfAssinatura { get; set; } = null!;

        [Required(ErrorMessage = "A data da assinatura é obrigatória")]
        public DateTime DataAssinatura { get; set; }

        [Required(ErrorMessage = "O nome do assinante é obrigatório")]
        public string NomeAssinante { get; set; } = null!;
    }
}

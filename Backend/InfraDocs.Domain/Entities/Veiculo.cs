using InfraDocs.Shared.Enums;

namespace InfraDocs.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public int OrganizacaoId { get; set; }
        public Organizacao Organizacao { get; set; } = null!;

        public string Placa { get; set; } = null!;
        public string UfPlaca { get; set; } = null!;

        public string MarcaModelo { get; set; } = null!;
        public string? Chassi { get; set; }
        public string? Renavam { get; set; }

        public int? AnoFabricacao { get; set; }
        public int? AnoModelo { get; set; }

        public TipoVeiculoEnum TipoVeiculo { get; set; }

        public StatusBasicoEnum StatusVeiculo { get; set; }
    }
}

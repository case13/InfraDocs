using System.ComponentModel.DataAnnotations;

namespace InfraDocs.Shared.Enums
{
    public enum TipoVeiculoEnum
    {
        [Display(Name = "Automóvel")]
        Automovel = 1,

        [Display(Name = "Motocicleta")]
        Motocicleta = 2,

        [Display(Name = "Caminhão")]
        Caminhao = 3,

        [Display(Name = "Caminhão Trator")]
        CaminhaoTrator = 4,

        [Display(Name = "Reboque")]
        Reboque = 5,

        [Display(Name = "Semi-Reboque")]
        SemiReboque = 6,

        [Display(Name = "Ônibus")]
        Onibus = 7,

        [Display(Name = "Outro")]
        Outro = 8
    }
}

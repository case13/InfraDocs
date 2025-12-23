using System.ComponentModel.DataAnnotations;

namespace InfraDocs.Shared.Enums
{
    public enum StatusRequerimentoEnum
    {
        [Display(Name = "Em Preenchimento")]
        EmPreenchimento = 1,

        [Display(Name = "Protocolado")]
        Protocolado = 2,

        [Display(Name = "Enviado")]
        Enviado = 3,

        [Display(Name = "Em Análise")]
        EmAnalise = 4,

        [Display(Name = "Deferido")]
        Deferido = 5,

        [Display(Name = "Indeferido")]
        Indeferido = 6,

        [Display(Name = "Arquivado")]
        Arquivado = 7
    }
}

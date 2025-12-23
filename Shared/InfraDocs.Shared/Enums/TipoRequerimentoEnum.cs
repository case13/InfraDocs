using System.ComponentModel.DataAnnotations;

namespace InfraDocs.Shared.Enums
{
    public enum TipoRequerimentoEnum
    {
        [Display(Name = "Suspensão Temporária da Restrição Administrativa")]
        SuspensaoTemporariaRestricaoAdministrativa = 1,

        [Display(Name = "Outros")]
        Outros = 2
    }
}

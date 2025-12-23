using System.ComponentModel.DataAnnotations;

namespace InfraDocs.Shared.Enums
{
    public enum TipoDocumentoEnum
    {
        [Display(Name = "CPF")]
        CPF = 1,
        [Display(Name = "CNPJ")]
        CNPJ = 2
    }
}
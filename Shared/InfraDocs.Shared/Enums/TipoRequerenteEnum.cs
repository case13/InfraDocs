using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraDocs.Shared.Enums
{
    public enum TipoRequerenteEnum
    {
        [Display(Name = "Proprietário")]
        Proprietario = 1,

        [Display(Name = "Condutor")]
        Condutor = 2,

        [Display(Name = "Procurador")]
        Procurador = 3,

        [Display(Name = "Outro")]
        Outro = 4
    }
}

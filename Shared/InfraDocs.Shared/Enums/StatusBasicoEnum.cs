using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraDocs.Shared.Enums
{
    public enum StatusBasicoEnum
    {
        [Display(Name = "Ativo")]
        Ativo = 1,
        [Display(Name = "Inativo")]
        Inativo = 2
    }
}

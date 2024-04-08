using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ActivoFijo.Core.Dto.CAT
{
    public class EspecificoGastoDto
    {
        public int IdEspecifico { get; set; }
        [Required]
        [StringLength(10)]
        public string CodigoEspecifico { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreEspecifico { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ActivoFijo.Core.Dto.CAT
{
    public class ClasificacionActivoFijoDto
    {
        // Declaracion de propiedades y metodos
        public int IdClasificacionActivoFijo {  get; set; }
        public int IdEspecifico { get; set; }

        [StringLength(6)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion {  get; set; }

    }
}

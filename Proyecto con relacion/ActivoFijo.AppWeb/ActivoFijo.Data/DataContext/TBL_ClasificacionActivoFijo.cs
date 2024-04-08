
namespace ActivoFijo.Data.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CAT.TBL_ClasificacionActivoFijo")]
    public partial class TBL_ClasificacionActivoFijo
    {
        public TBL_ClasificacionActivoFijo()
        {
            //Pendiente por rellenar
        }

        // Declaracion de los campos de la tabla
        [Key]
        public int IdClasificacionActivoFijo { get; set; }

        public int IdEspecifico { get; set; }

        [StringLength(6)]
        public string Codigo { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        // Fin

        // Declaracion de las relaciones con otras tablas
        // - Foraneas
        public virtual TBL_EspecificoGasto TBL_EspecificoGasto { get; set; }



    }
}

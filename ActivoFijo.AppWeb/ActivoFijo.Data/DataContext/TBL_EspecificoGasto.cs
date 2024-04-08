namespace ActivoFijo.Data.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CAT.TBL_EspecificoGasto")]
    public partial class TBL_EspecificoGasto
    {
        public TBL_EspecificoGasto()
        {
            // Pediente de rellenar
        }

        /// <summary>
        /// Especificacion de las propiedades
        /// </summary>
        [Key]
        public int IdEspecifico { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoEspecifico { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreEspecifico { get; set; }

    }
}

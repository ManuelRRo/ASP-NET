using System.Data.Entity;

namespace ActivoFijo.Data.DataContext
{
    public partial class ActivoFijoModel : DbContext
    {
        public ActivoFijoModel() : base("name=ActivoFijoModel")
        {

        }

        public virtual DbSet<TBL_ClasificacionActivoFijo> TBL_ClasificacionActivoFijo { get; set; }
        public virtual DbSet<TBL_EspecificoGasto> TBL_EspecificoGasto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tabla TBL_ClasificacionActivoFijo
            modelBuilder.Entity<TBL_ClasificacionActivoFijo>().Property(e => e.Codigo).IsUnicode(false);
            modelBuilder.Entity<TBL_ClasificacionActivoFijo>().Property(e => e.Descripcion).IsUnicode(false);
            // Fin

            // Tabla TBL_EspecificoGasto
            modelBuilder.Entity<TBL_EspecificoGasto>().Property(e => e.CodigoEspecifico).IsUnicode(false);
            modelBuilder.Entity<TBL_EspecificoGasto>().Property(e => e.NombreEspecifico).IsUnicode(false);
            modelBuilder.Entity<TBL_EspecificoGasto>().HasMany(e => e.TBL_ClasificacionActivoFijos)
                .WithRequired(e => e.TBL_EspecificoGasto).WillCascadeOnDelete(false);
            // Fin 
        }
    }
}

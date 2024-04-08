using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;

namespace ActivoFijo.Data.DataContext
{
    public partial class ActivoFijoModel : DbContext
    {
        public ActivoFijoModel() : base("name=ActivoFijoModel")
        {

        }

        public virtual DbSet<TBL_EspecificoGasto> TBL_EspecificoGasto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBL_EspecificoGasto>().Property(e => e.CodigoEspecifico).IsUnicode(false);
            modelBuilder.Entity<TBL_EspecificoGasto>().Property(e => e.NombreEspecifico).IsUnicode(false);
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVCClinica.Data
{
    public partial class DBMedicosContext : DbContext
    {
        public DBMedicosContext()
            : base("name=DBMedicosContext")
        {
        }

        public virtual DbSet<Medico> Medicos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Apellido)
                .IsUnicode(false);
        }
    }
}

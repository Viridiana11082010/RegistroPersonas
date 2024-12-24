using Microsoft.EntityFrameworkCore;
using Registro.Models;

namespace Registro.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options) : base (options)
        {
             
        }
        public DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(tb =>
            {
                tb.HasKey(col => col.IdPersona);
                tb.Property(col => col.IdPersona)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre).HasMaxLength(50);


            });
            modelBuilder.Entity<Persona>().ToTable("Personas");
        }

    }
}

using API_APP.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_APP.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); //indice para evitar duplicados
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique(); //Indices Compuestos
        }

        public DbSet<Country> Countries { get; set; } //mapea en SQL creando la tabla

        public DbSet<State> States { get; set; }
    }
}

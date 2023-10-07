using Microsoft.EntityFrameworkCore;

namespace API_APP.DAL.Entities
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
        }

        public DbSet<Country> Countries { get; set; } //mapea en SQL creando la tabla
    }
}

using Microsoft.EntityFrameworkCore;
using Mascota.App.Dominio;


namespace Mascota.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas {get; set;}

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
            .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MascotaFeliz.Data");
        }

     }  
    }
}
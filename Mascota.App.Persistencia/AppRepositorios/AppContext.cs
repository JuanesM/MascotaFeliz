using Mascota.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Mascota.App.Persistencia
{
    public class AppContext : DbContext
    {
       // public DbSet<Persona> Personas {get;set;} 
         public DbSet<Propietario> Propietarios {get;set;} 
        public DbSet<Veterinario> Veterinarios {get;set;} 
        public DbSet<Pet> Pets {get;set;} 
         public DbSet<Visita> Visitas {get;set;} 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {       
            if(!optionsBuilder.IsConfigured) 
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =MascotaData");
            }
        } 

    } 

}
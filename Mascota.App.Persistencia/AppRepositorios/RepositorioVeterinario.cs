using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        List<Veterinario> veterinarios;
        public RepositorioVeterinario(){
            veterinarios = new List<Veterinario>(){
                new Veterinario {Id= 1, Nombre = "Miguel", Apellido = "Gómez", cedula = 1059814620, Telefono = "3206807252", TarjetaProfesional ="SN 2050"},
                new Veterinario {Id= 2, Nombre = "Angel", Apellido = "Sánchez", cedula = 1059814616, Telefono = "3122302658", TarjetaProfesional = "SN 8590"}
            };
        }
        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinario(){
            return veterinarios;
        }
    }
}
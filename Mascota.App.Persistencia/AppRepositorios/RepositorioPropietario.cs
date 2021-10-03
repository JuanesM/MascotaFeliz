using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        List<Propietario> propietarios;
        public RepositorioPropietario(){
            propietarios = new List<Propietario>(){
                new Propietario {Id= 1, Nombre = "Miguel", Apellido = "Gómez", cedula = 1059814620, Telefono = "3206807252", Direccion = "Cr 9A #7-48"},
                new Propietario {Id= 2, Nombre = "Angel", Apellido = "Sánchez", cedula = 1059814616, Telefono = "3122302658", Direccion = "Cr 5B #20-12"}
            };
        }
        IEnumerable<Propietario> IRepositorioPropietario.GetAllPropietario(){
            return propietarios;
        }
    }
}
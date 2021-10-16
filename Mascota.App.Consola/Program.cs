using System;
using Mascota.App.Dominio;
using Mascota.App.Persistencia;

namespace Mascota.App.Consola
{
    class Program
    {
        private static IRepositorioPropietario _repoPropietario =new RepositorioPropietario(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("ya casi lo logras!");
           // AddPropietario();
           BuscarPropietario(1);
        }
        private static void AddPropietario()
        {
            var propietario = new Propietario()
            {
            
                Nombre="Jhon",
                Apellidos="Nova",
                Identificacion="12121",
                Telefono="233423",
                Direccion="Bogota"
            };
            _repoPropietario.AddPropietario(propietario);
        }
        private static void BuscarPropietario(int IdPropietario)
        {
            var propietario = _repoPropietario.GetPropietario(IdPropietario);
            Console.WriteLine(propietario.Nombre);
        }
    }
}

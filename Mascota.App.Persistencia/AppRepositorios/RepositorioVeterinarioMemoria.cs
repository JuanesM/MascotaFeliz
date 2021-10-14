using System.Collections.Generic;
using System.Linq;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public class RepositorioVeterinarioMemoria : IRepositorioVeterinario
    {

        List<Veterinario> veterinario;

        public RepositorioVeterinarioMemoria()
        {
            veterinario = new List<Veterinario>()
            {
                 new Veterinario{Id=11,Nombre="Jhon",Apellidos="Nova",Identificacion=10939393,Telefono="312112322",TarjetaProfesional="SN 7990"},//;Telefono="312112322",TarjetaProfesional="cr4 #32 S 01"}
                 new Veterinario{Id=12,Nombre="Miguel",Apellidos="Nova",Identificacion=10939393,Telefono="312112322",TarjetaProfesional="SN 7990"},
                 new Veterinario{Id=13,Nombre="Daniel",Apellidos="Nova",Identificacion=10939393,Telefono="312112322",TarjetaProfesional="SN 7990"},
                 new Veterinario{Id=14,Nombre="Camilo",Apellidos="Nova",Identificacion=10939393,Telefono="312112322",TarjetaProfesional="SN 7990"},
                 new Veterinario{Id=15,Nombre="Juan",Apellidos="Nova",Identificacion=10939393,Telefono="312112322",TarjetaProfesional="SN 7990"}

            };
        }
        public IEnumerable<Veterinario> GetAll()
        {
            return veterinario;
        }
        public Veterinario GetVeterinarioPorId(int veterinarioId)
        {
            return veterinario.SingleOrDefault(v => v.Id == veterinarioId);
        }
        public IEnumerable<Veterinario> GetVeterinarioPorFiltro(string filtro)
        {
            throw new System.NotImplementedException();
        }

        public Veterinario Update(Veterinario veterinarioActualizado)
        {
            var veterinarios = veterinario.SingleOrDefault(p => p.Id == veterinarioActualizado.Id);
            if (veterinario != null)
            {
                veterinarios.Id = veterinarioActualizado.Id;
                veterinarios.Nombre = veterinarioActualizado.Nombre;
                veterinarios.Apellidos = veterinarioActualizado.Apellidos;
                veterinarios.Identificacion = veterinarioActualizado.Identificacion;
                veterinarios.Telefono = veterinarioActualizado.Telefono;
                veterinarios.TarjetaProfesional = veterinarioActualizado.TarjetaProfesional;
            }
            return veterinarios;
        }
        public Veterinario Add(Veterinario nuevoVeterinario)
        {
            nuevoVeterinario.Id = veterinario.Max(r => r.Id) + 1;
            veterinario.Add(nuevoVeterinario);
            return nuevoVeterinario;
        }

    }
}
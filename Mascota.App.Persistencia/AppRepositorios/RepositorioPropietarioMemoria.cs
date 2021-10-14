using System;
using System.Collections.Generic;
using System.Linq;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public class RepositorioPropietarioMemoria : IRepositorioPropietario
    {
        List<Propietario> propietario;

        public RepositorioPropietarioMemoria()
        {
            propietario = new List<Propietario>()
            {
                new Propietario{Id=1,Nombre="Jhon",Apellidos="Nova",Identificacion=10939393,Telefono="312112322",Direccion="cr4 #32 S 01"},//;Telefono="312112322",Direccion="cr4 #32 S 01"}
                new Propietario{Id=2,Nombre="Miguel",Apellidos="Gomez",Identificacion=10939393,Telefono="312112322",Direccion="cr4 #32 S 01"},
                new Propietario{Id=3,Nombre="Daniel",Apellidos="Roa",Identificacion=10939393,Telefono="312112322",Direccion="cr4 #32 S 01"},
                new Propietario{Id=4,Nombre="Camilo",Apellidos="Cardena",Identificacion=10939393,Telefono="312112322",Direccion="cr4 #32 S 01"},
                new Propietario{Id=5,Nombre="Juan",Apellidos="stevan",Identificacion=10939393,Telefono="312112322",Direccion="cr4 #32 S 01"}
            };
        }

        public IEnumerable<Propietario> GetAll()
        {
            return propietario;
        }
        public Propietario GetPropietarioPorId(int propietarioId)
        {
            return propietario.SingleOrDefault(s => s.Id == propietarioId);
        }
        
        public IEnumerable<Propietario> GetPropietarioPorFiltro(string filtro = null)
        {
            var propietarios = GetAll();
            
            if (propietarios != null) { // Si se tienen Propietarios
                if (!String.IsNullOrEmpty(filtro)) { // Si el filtro tiene algún valor

                    propietarios = propietarios.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return propietarios;
        }

        public Propietario Update(Propietario propietarioActualizado)
        {
            var propietarios = propietario.SingleOrDefault(p => p.Id == propietarioActualizado.Id);
            if (propietarios != null)
            {
                propietarios.Id = propietarioActualizado.Id;
                propietarios.Nombre = propietarioActualizado.Nombre;
                propietarios.Apellidos = propietarioActualizado.Apellidos;
                propietarios.Identificacion = propietarioActualizado.Identificacion;
                propietarios.Telefono = propietarioActualizado.Telefono;
                propietarios.Direccion = propietarioActualizado.Direccion;
            }
            return propietarios;
        }
        public Propietario Add(Propietario nuevoPropietario)
        {
            nuevoPropietario.Id=propietario.Max(r=> r.Id)+1;
            propietario.Add(nuevoPropietario);
            return nuevoPropietario;
        }

        public Propietario Delete(Propietario deletePropietario)
        {
            //var propietarios = propietario.Find(deletePropietario);
            var propietarios = propietario.SingleOrDefault(p => p.Id == deletePropietario.Id);
            if (propietarios != null)
            {
                propietario.Remove(propietarios);
                
            }
            return propietarios;
        }

        
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly AppContext _appContext;
        public RepositorioPropietario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Propietario> GetPropietarioPorFiltro(string filtro)
        {
            var propietarios = GetAllPropietarios();
            
            if (propietarios != null) { // Si se tienen Propietarios
                if (!String.IsNullOrEmpty(filtro)) { // Si el filtro tiene algún valor

                    propietarios = propietarios.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return propietarios;
        }

        Propietario IRepositorioPropietario.AddPropietario(Propietario propietario)
        {
            var propietarioAdicionado = _appContext.Propietarios.Add(propietario);
            _appContext.SaveChanges();
            return propietarioAdicionado.Entity;
        }

        void IRepositorioPropietario.DeletePropietario(int IdPersona)
        {
            var propietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.Id == IdPersona);
            if (propietarioEncontrado == null)
                return;
            _appContext.Propietarios.Remove(propietarioEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Propietario> GetAllPropietarios()
        {
            return _appContext.Propietarios;
        }

        Propietario IRepositorioPropietario.GetPropietario(int IdPersona)
        {
            return _appContext.Propietarios.FirstOrDefault(p => p.Id == IdPersona);
        }

        Propietario IRepositorioPropietario.UpdatePropietario(Propietario propietario)
        {
            var propietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.Id == propietario.Id);
            if (propietario != null)
            {

                propietarioEncontrado.Nombre = propietario.Nombre;
                propietarioEncontrado.Apellidos = propietario.Apellidos;
                propietarioEncontrado.Identificacion = propietario.Identificacion;
                propietarioEncontrado.Telefono = propietario.Telefono;

                _appContext.SaveChanges();
            }
            return propietarioEncontrado;
        }
    }

}


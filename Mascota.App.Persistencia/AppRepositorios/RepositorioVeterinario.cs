using System;
using System.Collections.Generic;
using System.Linq;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        
        private readonly AppContext _appContext;
        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Veterinario> GetVeterinarioPorFiltro(string filtro)
        {
            var veterinarios = GetAllVeterinarios();
            
            if (veterinarios != null) { // Si se tienen Propietarios
                if (!String.IsNullOrEmpty(filtro)) { // Si el filtro tiene algún valor

                    veterinarios = veterinarios.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return veterinarios;
        }



        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado = _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

        void IRepositorioVeterinario.DeleteVeterinario(int IdVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == IdVeterinario);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            return _appContext.Veterinarios;
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(int IdVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(v => v.Id == IdVeterinario);
        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == veterinario.Id);
            if (veterinario != null)
            {

                veterinarioEncontrado.Nombre = veterinario.Nombre;
                veterinarioEncontrado.Apellidos = veterinario.Apellidos;
                veterinarioEncontrado.Identificacion = veterinario.Identificacion;
                veterinarioEncontrado.Telefono = veterinario.Telefono;

                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }
    }
}




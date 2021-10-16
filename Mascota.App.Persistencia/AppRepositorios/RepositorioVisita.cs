using System;
using System.Collections.Generic;
using System.Linq;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia
{
    public class RepositorioVisita : IRepositorioVisita
    {
        private readonly AppContext _appContext;
        public RepositorioVisita(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Visita> GetVisitaPorFiltro(string filtro)
        {
           var visitas = GetAllVisitas();
            
            if (visitas != null) { // Si se tienen Visitas
                if (!String.IsNullOrEmpty(filtro)) { // Si el filtro tiene algún valor

                    visitas = visitas.Where(s => s.FechaVisita.Contains(filtro));
                }
            }
            return visitas;
        }


        Visita IRepositorioVisita.AddVisita(Visita visita)
        {
            var visitaAdicionado = _appContext.Visitas.Add(visita);
            _appContext.SaveChanges();
            return visitaAdicionado.Entity;
        }

        void IRepositorioVisita.DeleteVisita(int IdVisita)
        {
            var visitaEncontrado = _appContext.Visitas.FirstOrDefault(v => v.Id == IdVisita);
            if (visitaEncontrado == null)
                return;
            _appContext.Visitas.Remove(visitaEncontrado);
            _appContext.SaveChanges();
        }

         public IEnumerable<Visita> GetAllVisitas()
        {
            return _appContext.Visitas;
        }

        Visita IRepositorioVisita.GetVisita(int IdVisita)
        {
            return _appContext.Visitas.FirstOrDefault(v => v.Id == IdVisita);
        }

        Visita IRepositorioVisita.UpdateVisita(Visita visita)
        {
            var visitaEncontrado = _appContext.Visitas.FirstOrDefault(v => v.Id == visita.Id);
            if (visita != null)
            {

                visitaEncontrado.Id= visita.Id;
                visitaEncontrado.Pet = visita.Pet;
                visitaEncontrado.Veterinario = visita.Veterinario;
                visitaEncontrado.FechaVisita = visita.FechaVisita;
                visitaEncontrado.Recomendaciones = visita.Recomendaciones;


                _appContext.SaveChanges();
            }
            return visitaEncontrado;
        }
    }

}


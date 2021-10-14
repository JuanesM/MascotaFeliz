using System.Collections.Generic;
using System.Linq;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public class RepositorioVisitaMemoria : IRepositorioVisita
    {
       List<Visita> visita;
       public RepositorioVisitaMemoria()
       {
           visita = new List<Visita>()
           {
               new Visita{Id=1,Recomendaciones="Aplicar Vacunas", FechaVisita="2021/07/01"},
               new Visita{Id=2,Recomendaciones="No darle chocolate", FechaVisita="2021/07/01"},
               new Visita{Id=3,Recomendaciones="Sacarlo a pasear 2 veces al día", FechaVisita="2021/07/01"}
           };
       }

        public IEnumerable<Visita> GetAll()
        {
            return visita;
        }
   public Visita GetVisitaPorId(int visitaId)
        {
            return visita.SingleOrDefault(a => a.Id == visitaId);
        }
        public IEnumerable<Visita> GetVisitaPorFiltro(string filtro)
        {
            throw new System.NotImplementedException();
        }

        public Visita Update(Visita visitaActualizado)
        {
            var visitas = visita.SingleOrDefault(a => a.Id == visitaActualizado.Id);
            if (visita != null)
            {
                visitas.Id = visitaActualizado.Id;
                visitas.Pet = visitaActualizado.Pet;
                visitas.Veterinario = visitaActualizado.Veterinario;
                visitas.FechaVisita = visitaActualizado.FechaVisita;
                visitas.Recomendaciones= visitaActualizado.Recomendaciones;

               
            }
            return visitas;
        }
        public Visita Add(Visita nuevoVisita)
        {
            nuevoVisita.Id=visita.Max(r=> r.Id)+1;
            visita.Add(nuevoVisita);
            return nuevoVisita;
        }

    }
}


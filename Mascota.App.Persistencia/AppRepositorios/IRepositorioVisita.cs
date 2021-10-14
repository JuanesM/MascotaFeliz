using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public interface IRepositorioVisita
    {
         IEnumerable<Visita> GetAll();
    
        IEnumerable<Visita> GetVisitaPorFiltro(string filtro);
        Visita GetVisitaPorId(int visitaId);
        Visita Update(Visita visitaActualizado);
        Visita Add(Visita nuevoVisita);
    }
}
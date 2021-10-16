using System;
using System.Collections.Generic;
using Mascota.App.Dominio;
using System.Linq;

namespace Mascota.App.Persistencia
{
    public interface IRepositorioVisita
    {
        IEnumerable<Visita> GetAllVisitas();
        Visita AddVisita(Visita visita);
        Visita UpdateVisita(Visita visita);
        public void DeleteVisita(int IdVisita);
        Visita GetVisita(int IdVisita);

        IEnumerable <Visita> GetVisitaPorFiltro(string filtro);
    }
}
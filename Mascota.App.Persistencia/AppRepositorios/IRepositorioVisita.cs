using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public interface IRepositorioVisita
    {
         IEnumerable<Visita> GetAllVisita();
    }
}
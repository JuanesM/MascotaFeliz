using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia
{
    public interface IRepositorioPropietario
    {
         IEnumerable<Propietario> GetAllPropietario();
    }
}
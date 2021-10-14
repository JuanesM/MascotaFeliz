using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public interface IRepositorioPropietario
    {
         
         IEnumerable<Propietario> GetAll();
         IEnumerable <Propietario> GetPropietarioPorFiltro(string filtro);
         Propietario GetPropietarioPorId(int propietarioId);
         Propietario Update(Propietario propietarioActualizado);
         Propietario Add(Propietario nuevoPropietario);

         Propietario Delete(Propietario deletePropietario);
         
    }
}
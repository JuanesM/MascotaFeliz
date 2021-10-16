using System;
using System.Collections.Generic;
using Mascota.App.Dominio;
using System.Linq;

namespace Mascota.App.Persistencia
{
    public interface IRepositorioPropietario
    {

        IEnumerable<Propietario> GetAllPropietarios();
        Propietario AddPropietario(Propietario propietario);
        Propietario UpdatePropietario(Propietario propietario);
        public void DeletePropietario(int IdPropietario);
        Propietario GetPropietario(int IdPropietario);
        IEnumerable <Propietario> GetPropietarioPorFiltro(string filtro);
      






    }
}
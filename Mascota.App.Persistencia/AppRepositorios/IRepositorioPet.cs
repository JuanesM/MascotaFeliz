using System.Collections.Generic;
using Mascota.App.Dominio.Entidades;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public interface IRepositorioPet
    {
         IEnumerable<Pet> GetAllPet();
    }
}
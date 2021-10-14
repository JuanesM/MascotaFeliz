using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public interface IRepositorioPet
    {
        IEnumerable<Pet> GetAll();

        IEnumerable<Pet> GetPetPorFiltro(string filtro);
        Pet GetPetPorId(int petId);
        Pet Update(Pet petActualizado);
        Pet Add(Pet nuevoPet);
    }
}
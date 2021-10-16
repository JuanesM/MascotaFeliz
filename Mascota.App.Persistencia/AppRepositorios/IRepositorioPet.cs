using System;
using System.Collections.Generic;
using Mascota.App.Dominio;
using System.Linq;

namespace Mascota.App.Persistencia
{
    public interface IRepositorioPet
    {

        IEnumerable<Pet> GetAllPets();
        Pet AddPet(Pet pet);
        Pet UpdatePet(Pet pet);
        public void DeletePet(int IdPet);
        Pet GetPet(int IdPet);
        
         IEnumerable<Pet> GetPetPorFiltro(string filtro);






    }
}
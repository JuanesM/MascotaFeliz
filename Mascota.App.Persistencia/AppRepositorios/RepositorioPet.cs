using System;
using System.Collections.Generic;
using System.Linq;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia
{
    public class RepositorioPet : IRepositorioPet
    {
        private readonly AppContext _appContext;
        public RepositorioPet(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Pet> GetPetPorFiltro(string filtro)
        {
            var pets = GetAllPets();
            
            if (pets != null) { // Si se tienen Pets
                if (!String.IsNullOrEmpty(filtro)) { // Si el filtro tiene algún valor

                    pets = pets.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return pets;
        }

        Pet IRepositorioPet.AddPet(Pet pet)
        {
            var petAdicionado = _appContext.Pets.Add(pet);
            _appContext.SaveChanges();
            return petAdicionado.Entity;
        }

        void IRepositorioPet.DeletePet(int IdPet)
        {
            var petEncontrado = _appContext.Pets.FirstOrDefault(m => m.Id == IdPet);
            if (petEncontrado == null)
                return;
            _appContext.Pets.Remove(petEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _appContext.Pets;
        }

        Pet IRepositorioPet.GetPet(int IdPet)
        {
            return _appContext.Pets.FirstOrDefault(m => m.Id == IdPet);
        }

        Pet IRepositorioPet.UpdatePet(Pet pet)
        {
            var petEncontrado = _appContext.Pets.FirstOrDefault(m => m.Id == pet.Id);
            if (pet != null)
            {

                petEncontrado.Id= pet.Id;
                petEncontrado.Nombre = pet.Nombre;
                petEncontrado.Tipo = pet.Tipo;
                petEncontrado.Temperatura = pet.Temperatura;
                petEncontrado.Peso = pet.Peso;
                petEncontrado.FrecuenciaRespiratoria = pet.FrecuenciaRespiratoria;
                petEncontrado.FrecuenciaCardiaca = pet.FrecuenciaCardiaca;
                petEncontrado.Estado_Animo = pet.Estado_Animo;
                petEncontrado.Propietario = pet.Propietario;

                _appContext.SaveChanges();
            }
            return petEncontrado;
        }
    }

}


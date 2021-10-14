using System.Collections.Generic;
using System.Linq;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public class RepositorioPetMemoria : IRepositorioPet
    {
        List<Pet> pet;
        public RepositorioPetMemoria()
        {
            pet= new List<Pet>()
            {
                new Pet{Id=1,Nombre="Firulais",Tipo="Perro",Temperatura="40",Peso="6k",FrecuenciaRespiratoria="90",FrecuenciaCardiaca="60", Estado_Animo="Saludable"},
                new Pet{Id=2,Nombre="Michi",Tipo="Gato",Temperatura="35",Peso="3k",FrecuenciaRespiratoria="90",FrecuenciaCardiaca="60", Estado_Animo="Saludable"},
                new Pet{Id=3,Nombre="Pintas",Tipo="Perro",Temperatura="40",Peso="6k",FrecuenciaRespiratoria="90",FrecuenciaCardiaca="60", Estado_Animo="Saludable"}
            };
        }
        public IEnumerable<Pet> GetAll()
        {
            return pet;
        }
         public Pet GetPetPorId(int petId)
        {
            return pet.SingleOrDefault(s => s.Id == petId);
        }
        public IEnumerable<Pet> GetPetPorFiltro(string filtro)
        {
            throw new System.NotImplementedException();
        }

        public Pet Update(Pet petActualizado)
        {
            var pets = pet.SingleOrDefault(p => p.Id == petActualizado.Id);
            if (pets != null)
            {
                pets.Id = petActualizado.Id;
                pets.Nombre = petActualizado.Nombre;
                pets.Tipo = petActualizado.Tipo;
                pets.Temperatura = petActualizado.Temperatura;
                pets.Peso = petActualizado.Peso;
                pets.FrecuenciaRespiratoria = petActualizado.FrecuenciaRespiratoria;
                pets.FrecuenciaCardiaca = petActualizado.FrecuenciaCardiaca;
                pets.Estado_Animo = petActualizado.Estado_Animo;
                pets.Propietario = petActualizado.Propietario;
               
            }
            return pets;
        }
        public Pet Add(Pet nuevoPet)
        {
            nuevoPet.Id=pet.Max(r=> r.Id)+1;
            pet.Add(nuevoPet);
            return nuevoPet;
        }

    }
}


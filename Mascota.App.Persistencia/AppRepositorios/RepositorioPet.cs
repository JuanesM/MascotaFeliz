using System.Collections.Generic;
using Mascota.App.Dominio.Entidades;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public class RepositorioPet : IRepositorioPet
    {
        List<Pet> pets;
        public RepositorioPet(){
            pets = new List<Pet>(){
                new Pet {Id = 1, Nombre = "Firulais", Tipo = "Perro", Temperatura = 25.8f, Peso = 12.5f, FrecuenciaRespiratoria = 120, FrecuenciaCardiaca = 80, EstadoAnimo = "Arrecho"},
                new Pet {Id = 2, Nombre = "Doraemon", Tipo = "Gato", Temperatura = 20, Peso = 6.4f, FrecuenciaRespiratoria = 150, FrecuenciaCardiaca = 100, EstadoAnimo = "Gruñon"}

            };
        }
        IEnumerable<Pet> IRepositorioPet.GetAllPet(){
            return pets;
        }
    }
}
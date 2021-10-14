using System;
namespace Mascota.App.Dominio
{

 public class Pet
     {
        public int Id{get; set;}
        public string Nombre{get; set;}
        public string Tipo {get; set;}
        public string  Temperatura {get; set;}
        public string Peso {get; set;}
        public string FrecuenciaRespiratoria{get; set;}
        public string FrecuenciaCardiaca{get; set;}
        public string Estado_Animo{get; set;}
        public Propietario Propietario {get; set;}

     }
}
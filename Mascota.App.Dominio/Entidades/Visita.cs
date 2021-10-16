using System;
namespace Mascota.App.Dominio
{
  public class Visita
        {
            public int Id {get; set;}
            public Pet Pet {get; set;}
            public Veterinario Veterinario{get; set;}
            public string FechaVisita{get; set;}
            public string Recomendaciones {get; set;}


        }


}
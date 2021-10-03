using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public class RepositorioVisita : IRepositorioVisita
    {
        List<Visita> visitas;
        public RepositorioVisita(){
            visitas = new List<Visita>(){
                new Visita {Recomendaciones = "Evitar darle comida de sal", FechaVisita = "25/05/2021"},
                new Visita {Recomendaciones = "No darle chocolates", FechaVisita = "01/01/2020"},
                new Visita {Recomendaciones = "Estar al día con las vacunas", FechaVisita = "10/10/2019"}
            };
        }
        IEnumerable<Visita> IRepositorioVisita.GetAllVisita(){
            return visitas;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mascota.App.Dominio;
using Mascota.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mascota.App.Frontend.Pages
{
    public class VisitaModel : PageModel
    {
        private readonly IRepositorioVisita repositorioVisita;
        public IEnumerable<Visita> Visitas { get; set; }
        public VisitaModel(IRepositorioVisita repositorioVisita)
        {
            this.repositorioVisita = repositorioVisita;
        }

        public void OnGet()
        {
            Visitas = repositorioVisita.GetAll();
        }
    }
}

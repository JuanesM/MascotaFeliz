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
    public class DetailsVisitaModel : PageModel
    {
        private readonly IRepositorioVisita repositorioVisita;
        public Visita Visita { get; set; }
        public DetailsVisitaModel(IRepositorioVisita repositorioVisita)
        {
            this.repositorioVisita = repositorioVisita;
        }
        public IActionResult OnGet(int VisitaId)
        {
            Visita = repositorioVisita.GetVisitaPorId(VisitaId);
            if (Visita == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }


    }
}

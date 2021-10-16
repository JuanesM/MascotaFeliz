using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mascota.App.Dominio;
using Mascota.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mascota.App.Frontend.Pages
{
    public class EditVisitaModel : PageModel
    {
        private readonly IRepositorioVisita repositorioVisita;
        [BindProperty]
        public Visita Visita { get; set; }
        public EditVisitaModel()
        {
            this.repositorioVisita =new RepositorioVisita(new Mascota.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? visitaId)
        {
             if (visitaId.HasValue)
            {
                Visita = repositorioVisita.GetVisita(visitaId.Value);
            }
            else
            {
                Visita = new Visita();
            }
            if (Visita == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }

        
        public IActionResult OnPost()
 
            {
            if(!ModelState.IsValid){
                return Page();
            }
            if (Visita.Id > 0)
            {
                Visita = repositorioVisita.UpdateVisita(Visita);
            }
            else
            {
                repositorioVisita.AddVisita(Visita);
            }
            return Page();
        }
        }
    }

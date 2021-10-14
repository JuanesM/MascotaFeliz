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
    public class EditVisitaModel : PageModel
    {
        private readonly IRepositorioVisita repositorioVisita;
        [BindProperty]
        public Visita Visita { get; set; }
        public EditVisitaModel(IRepositorioVisita repositorioVisita)
        {
            this.repositorioVisita = repositorioVisita;
        }
        public IActionResult OnGet(int? VisitaId)
        {
             if (VisitaId.HasValue)
            {
                Visita = repositorioVisita.GetVisitaPorId(VisitaId.Value);
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
        // {
        //     Propietario = repositorioPropietario.Update(Propietario);
        //     return Page();

            {
            if(!ModelState.IsValid){
                return Page();
            }
            if (Visita.Id > 0)
            {
                Visita = repositorioVisita.Update(Visita);
            }
            else
            {
                repositorioVisita.Add(Visita);
            }
            return Page();
        }
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mascota.App.Dominio;
using Mascota.App.Persistencia;

namespace Mascota.App.Frontend.Pages
{
    public class DetailsPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        public Propietario Propietario { get; set; }
        public DetailsPropietarioModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new Mascota.App.Persistencia.AppContext());

        }
        public IActionResult OnGet(int propietarioId)
        {
            Propietario = repositorioPropietario.GetPropietario(propietarioId);
            if (Propietario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                
                    return Page();
                
            }



        }
    }
}

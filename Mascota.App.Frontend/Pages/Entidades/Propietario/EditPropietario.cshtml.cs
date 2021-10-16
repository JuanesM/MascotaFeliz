using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mascota.App.Dominio;
using Mascota.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class EditPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        [BindProperty]

        public Propietario Propietario{set;get;}

        public EditPropietarioModel()
        {
            this.repositorioPropietario=new RepositorioPropietario(new Mascota.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? propietarioId)
        {
            if (propietarioId.HasValue)
            {
                Propietario = repositorioPropietario.GetPropietario(propietarioId.Value);
            }
            else
            {
                Propietario= new Propietario();
            }
            if (Propietario == null)
            {
                return RedirectToPage("./Notfound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                if (Propietario.Id>0)
                {
                    Propietario= repositorioPropietario.UpdatePropietario(Propietario);
                }
                else
                {
                    repositorioPropietario.AddPropietario(Propietario);
                }
                
                return Page();
        }
        
    }
}
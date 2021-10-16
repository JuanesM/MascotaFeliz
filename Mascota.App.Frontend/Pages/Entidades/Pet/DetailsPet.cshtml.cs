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
    public class DetailsPetModel : PageModel
    {
        private readonly IRepositorioPet repositorioPet;
        public Pet Pet { get; set; }
        public DetailsPetModel()
        {
            this.repositorioPet = new RepositorioPet(new Mascota.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int petId)
        {
            Pet = repositorioPet.GetPet(petId);
            if (Pet == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }


    }
}

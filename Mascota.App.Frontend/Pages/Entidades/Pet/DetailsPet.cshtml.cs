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
    public class DetailsPetModel : PageModel
    {
        private readonly IRepositorioPet repositorioPet;
        public Pet Pet { get; set; }
        public DetailsPetModel(IRepositorioPet repositorioPet)
        {
            this.repositorioPet = repositorioPet;
        }
        public IActionResult OnGet(int PetId)
        {
            Pet = repositorioPet.GetPetPorId(PetId);
            if (Pet == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }


    }
}

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
    public class EditPetModel : PageModel
    {
        private readonly IRepositorioPet repositorioPet;
        [BindProperty]
        public Pet Pet { get; set; }
        public EditPetModel(IRepositorioPet repositorioPet)
        {
            this.repositorioPet = repositorioPet;
        }
        public IActionResult OnGet(int? PetId)
        {
            if (PetId.HasValue)
            {
                Pet = repositorioPet.GetPetPorId(PetId.Value);
            }
            else
            {
                Pet = new Pet();
            }
            if (Pet == null)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Pet.Id > 0)
            {
                Pet = repositorioPet.Update(Pet);
            }
            else
            {
                repositorioPet.Add(Pet);
            }
            return Page();
        }
    }
}

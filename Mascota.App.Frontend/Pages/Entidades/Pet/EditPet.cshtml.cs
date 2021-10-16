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
    public class EditPetModel : PageModel
    {
        private readonly IRepositorioPet repositorioPet;
        [BindProperty]
        public Pet Pet { get; set; }
        public EditPetModel()
        {
            this.repositorioPet =new RepositorioPet(new Mascota.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? petId)
        {
            if (petId.HasValue)
            {
                Pet = repositorioPet.GetPet(petId.Value);
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
                Pet = repositorioPet.UpdatePet(Pet);
            }
            else
            {
                repositorioPet.AddPet(Pet);
            }
            return Page();
        }
    }
}

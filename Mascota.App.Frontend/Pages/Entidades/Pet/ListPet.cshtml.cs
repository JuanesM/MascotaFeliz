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
    public class ListPetModel : PageModel
    {
        public string FiltroBusqueda {get; set;}
        private readonly IRepositorioPet repositorioPets;
        public IEnumerable<Pet> Pets{get; set;}
        public Pet Pet {get; set;}
        public ListPetModel()
        {
            this.repositorioPets= new RepositorioPet(new Mascota.App.Persistencia.AppContext());
        }
        public void OnGet(string filtroBusqueda)
        {
            Pets=repositorioPets.GetAllPets();
            FiltroBusqueda = filtroBusqueda;
            Pets = repositorioPets.GetPetPorFiltro(filtroBusqueda);
        }
        public IActionResult OnGetDel(int petId)
        {
            Pet = repositorioPets.GetPet(petId);
            if (Pet == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                {
                    return Page();
                }
            }
            
        }
        public IActionResult OnPostDelete(int petId){
            repositorioPets.DeletePet(petId);
            return RedirectToPage();
            
        }
    }
}

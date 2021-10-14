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
    public class DetailsVetModel : PageModel
     {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public Veterinario Veterinario {get; set;}
        public DetailsVetModel(IRepositorioVeterinario repositorioVeterinario)
        {
            this.repositorioVeterinario= repositorioVeterinario;
        }
        public IActionResult  OnGet(int VeterinarioId)
        {
            Veterinario = repositorioVeterinario.GetVeterinarioPorId(VeterinarioId);
            if(Veterinario==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }
        
        
    }
}

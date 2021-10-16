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
    public class DetailsVetModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public Veterinario Veterinario { get; set; }
        public DetailsVetModel()
        {
            this.repositorioVeterinario = new RepositorioVeterinario(new Mascota.App.Persistencia.AppContext());

        }
        public IActionResult OnGet(int veterinarioId)
        {
            Veterinario = repositorioVeterinario.GetVeterinario(veterinarioId);
            if (Veterinario == null)
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
    }
}

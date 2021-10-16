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
    public class EditVetModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        [BindProperty]

        public Veterinario Veterinario{set;get;}

        public EditVetModel()
        {
            this.repositorioVeterinario=new RepositorioVeterinario(new Mascota.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? veterinarioId)
        {
            if (veterinarioId.HasValue)
            {
                Veterinario = repositorioVeterinario.GetVeterinario(veterinarioId.Value);
            }
            else
            {
                Veterinario= new Veterinario();
            }
            if (Veterinario == null)
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
                if (Veterinario.Id>0)
                {
                    Veterinario= repositorioVeterinario.UpdateVeterinario(Veterinario);
                }
                else
                {
                    repositorioVeterinario.AddVeterinario(Veterinario);
                }
                return Page();
        }
        
    }
}

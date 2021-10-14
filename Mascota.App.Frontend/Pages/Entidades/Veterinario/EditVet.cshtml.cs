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
    public class EditVetModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        [BindProperty]
        public Veterinario Veterinario { get; set; }
        public EditVetModel(IRepositorioVeterinario repositorioVeterinario)
        {
            this.repositorioVeterinario = repositorioVeterinario;
        }
        public IActionResult OnGet(int? VeterinarioId)
        {
             if (VeterinarioId.HasValue)
            {
                Veterinario = repositorioVeterinario.GetVeterinarioPorId(VeterinarioId.Value);
            }
            else
            {
                Veterinario = new Veterinario();
            }
            if (Veterinario == null)
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
            if(!ModelState.IsValid){
                return Page();
            }
            if (Veterinario.Id > 0)
            {
                Veterinario = repositorioVeterinario.Update(Veterinario);
            }
            else
            {
                repositorioVeterinario.Add(Veterinario);
            }
            return Page();
        }
        }
    }

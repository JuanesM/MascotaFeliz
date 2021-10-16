using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mascota.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Mascota.App.Dominio;

namespace Mascota.App.Frontend.Pages
{
    public class ListVeterinarioModel : PageModel
    {
        public string FiltroBusqueda {get; set;}
        private readonly IRepositorioVeterinario repositorioVeterinarios;
        public IEnumerable<Veterinario> Veterinarios { get; set; }

        public Veterinario Veterinario { get; set; }
        public ListVeterinarioModel()
        {
            this.repositorioVeterinarios = new RepositorioVeterinario(new Mascota.App.Persistencia.AppContext());
        }
        public void OnGet(string filtroBusqueda)
        {
            Veterinarios = repositorioVeterinarios.GetAllVeterinarios();
            FiltroBusqueda = filtroBusqueda;
            Veterinarios = repositorioVeterinarios.GetVeterinarioPorFiltro(filtroBusqueda);
        }
        public IActionResult OnGetDel(int veterinarioId)
        {
            Veterinario = repositorioVeterinarios.GetVeterinario(veterinarioId);
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
        public IActionResult OnPostDelete(int veterinarioId)
        {
            repositorioVeterinarios.DeleteVeterinario(veterinarioId);
            return RedirectToPage();
        }

    }
}

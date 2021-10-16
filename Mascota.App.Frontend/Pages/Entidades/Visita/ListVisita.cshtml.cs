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
    public class ListVisitaModel : PageModel
    {
        public string FiltroBusqueda {get; set;}
        private readonly IRepositorioVisita repositorioVisitas;
        public IEnumerable<Visita> Visitas { get; set; }

        public Visita Visita {get; set;}
        public ListVisitaModel()
        {
            this.repositorioVisitas = new RepositorioVisita(new Mascota.App.Persistencia.AppContext());
        }
        public void OnGet(string filtroBusqueda)
        {
            Visitas = repositorioVisitas.GetAllVisitas();
            FiltroBusqueda = filtroBusqueda;
            Visitas= repositorioVisitas.GetVisitaPorFiltro(filtroBusqueda);

        }
        public IActionResult OnGetDel(int visitaId)
        {
            Visita = repositorioVisitas.GetVisita(visitaId);
            if (Visita == null)
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
            public IActionResult OnPostDelete(int visitaId){
            repositorioVisitas.DeleteVisita(visitaId);
            return RedirectToPage();
            
        }
    }
}


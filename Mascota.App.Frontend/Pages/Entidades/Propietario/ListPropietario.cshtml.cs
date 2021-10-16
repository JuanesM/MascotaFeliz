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
    public class ListPropietarioModel : PageModel
    {
        public string FiltroBusqueda {get; set;}
        private readonly IRepositorioPropietario repositorioPropietarios;
        public IEnumerable<Propietario> Propietarios{get; set;}

        public Propietario Propietario {get; set;}

        

        public ListPropietarioModel()
        {
            this.repositorioPropietarios = new RepositorioPropietario(new Mascota.App.Persistencia.AppContext());
        }
        public void OnGet(string filtroBusqueda)
        {
            Propietarios = repositorioPropietarios.GetAllPropietarios();
            FiltroBusqueda = filtroBusqueda;
            Propietarios = repositorioPropietarios.GetPropietarioPorFiltro(filtroBusqueda);

        }
        public IActionResult OnGetDel(int propietarioId)
        {
            Propietario = repositorioPropietarios.GetPropietario(propietarioId);
            if (Propietario == null)
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
        public IActionResult OnPostDelete(int propietarioId){
            repositorioPropietarios.DeletePropietario(propietarioId);
            return RedirectToPage();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mascota.App.Dominio;
using Mascota.App.Persistencia.AppRepositorios;

namespace  Mascota.App.Frontend.Pages
{
    public class DetailsPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        public Propietario Propietario {get; set;}
        public DetailsPropietarioModel(IRepositorioPropietario repositorioPropietario)
        {
            this.repositorioPropietario= repositorioPropietario;
        }
        public IActionResult  OnGet(int PropietarioId)
        {
            Propietario = repositorioPropietario.GetPropietarioPorId(PropietarioId);
            if(Propietario==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }
        
        
    }
}

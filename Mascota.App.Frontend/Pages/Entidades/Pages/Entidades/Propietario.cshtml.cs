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
    public class PropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        public IEnumerable<Propietario> Propietarios{get;set;}
        public PropietarioModel(IRepositorioPropietario repositorioPropietario){
            this.repositorioPropietario = repositorioPropietario;
        }
        public void OnGet()
        {
            Propietarios = repositorioPropietario.GetAllPropietario();
        }
    }
}

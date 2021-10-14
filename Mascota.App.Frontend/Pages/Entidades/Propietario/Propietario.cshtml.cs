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
    public class PropietarioModel : PageModel
    {
        public string Filtrar {get; set;}
        private readonly IRepositorioPropietario repositorioPropietario;
        public IEnumerable<Propietario> Propietarios {get; set;}
        public PropietarioModel(IRepositorioPropietario repositorioPropietario)
        {
            this.repositorioPropietario=repositorioPropietario;
        }
        public void OnGet(string filtrar)
        {
            
            Propietarios=repositorioPropietario.GetAll();
            Filtrar = filtrar;
            Propietarios = repositorioPropietario.GetPropietarioPorFiltro(filtrar);
        }

        // public void OnPostSearch()
        // {
        //     Console.WriteLine(this.filtrar);
        //     this.filtrado= repositorioPropietario.GetPropietarioPorFiltro(this.filtrar);
        //     Console.WriteLine("Se está buscando por Nombre" + filtrado.Nombre);
        // }
        
    }
}

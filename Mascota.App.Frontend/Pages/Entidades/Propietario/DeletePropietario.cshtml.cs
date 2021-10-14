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
    public class DeletePropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        
        public Propietario Propietario {get;set;}

        public DeletePropietarioModel(IRepositorioPropietario repositorioPropietario){
            this.repositorioPropietario = repositorioPropietario;
        }

        public void OnGet(int PropietarioId)
        {
            Propietario = repositorioPropietario.GetPropietarioPorId(PropietarioId);
            if (Propietario == null){
                NotFound();
            }
            else {
                Page();
            }
        }

        public void OnPost(Propietario PropietarioId){
            repositorioPropietario.Delete(PropietarioId);
        }

        // public void OnPostDel(Propietario PropietarioId){
        //     repositorioPropietario.Delete(PropietarioId);
        //     Console.WriteLine("Se ha borrado correctamente");
        // }
    }
}

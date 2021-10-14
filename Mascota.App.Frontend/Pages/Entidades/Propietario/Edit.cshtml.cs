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
    public class EditModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        [BindProperty]
        public Propietario Propietario { get; set; }
        
        public EditModel(IRepositorioPropietario repositorioPropietario)
        {
            this.repositorioPropietario = repositorioPropietario;
        }
        public IActionResult OnGet(int? PropietarioId)
        {
             if (PropietarioId.HasValue)
            {
                Propietario = repositorioPropietario.GetPropietarioPorId(PropietarioId.Value);
            }
            else
            {
                Propietario = new Propietario();
            }
            if (Propietario == null)
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
            if (Propietario.Id > 0)
            {
                Propietario = repositorioPropietario.Update(Propietario);
            }
            else
            {
                repositorioPropietario.Add(Propietario);
            }
            return Page();
        }
        }
    }

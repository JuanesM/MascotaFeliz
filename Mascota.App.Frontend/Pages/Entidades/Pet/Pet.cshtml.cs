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
    public class PetModel : PageModel
    {
        private readonly IRepositorioPet repositorioPet;
        public IEnumerable<Pet> Pets{get; set;}
        public PetModel(IRepositorioPet repositorioPet)
        {
            this.repositorioPet=repositorioPet;
        }
        public void OnGet()
        {
            Pets=repositorioPet.GetAll();
        }
    }
}

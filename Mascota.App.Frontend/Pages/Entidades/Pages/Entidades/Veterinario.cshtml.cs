using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mascota.App.Dominio;
using Mascota.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mascota.App.Frontend.Pages
{
    public class VeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public IEnumerable<Veterinario> Veterinarios{get;set;}
        public VeterinarioModel(IRepositorioVeterinario repositorioVeterinario){
            this.repositorioVeterinario = repositorioVeterinario;
        }
        public void OnGet()
        {
            Veterinarios = repositorioVeterinario.GetAllVeterinario();
        }
    }
}

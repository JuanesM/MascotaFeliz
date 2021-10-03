using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
         IEnumerable<Veterinario> GetAllVeterinario();
    }
}
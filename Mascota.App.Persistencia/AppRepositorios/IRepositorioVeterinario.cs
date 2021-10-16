using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinarios();
        Veterinario AddVeterinario(Veterinario veterinario);
        Veterinario UpdateVeterinario(Veterinario veterinario);
        public void DeleteVeterinario(int IdVeterinario);
        Veterinario GetVeterinario(int IdVeterinario);

        IEnumerable <Veterinario> GetVeterinarioPorFiltro(string filtro);
        
    }
}
using System.Collections.Generic;
using Mascota.App.Dominio;

namespace Mascota.App.Persistencia.AppRepositorios
{
    public interface IRepositorioVeterinario
    {

        IEnumerable<Veterinario> GetAll();
        IEnumerable<Veterinario> GetVeterinarioPorFiltro(string filtro);
        Veterinario GetVeterinarioPorId(int veterinarioId);
        Veterinario Update(Veterinario  veterinarioActualizado);
        Veterinario Add(Veterinario nuevoVeterinario);
        
    }
}
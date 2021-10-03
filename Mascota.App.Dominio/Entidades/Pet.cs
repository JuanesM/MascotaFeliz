namespace Mascota.App.Dominio.Entidades
{
    public class Pet
    {
    public int Id{get; set;}
    public string Nombre {get; set;}
    public string Tipo{get; set;}
    public float Temperatura {get; set;}
    public float Peso {get; set;}
    public int FrecuenciaRespiratoria {get; set;}
    public int FrecuenciaCardiaca {get; set;}
    public string EstadoAnimo {get; set;}
    }
}
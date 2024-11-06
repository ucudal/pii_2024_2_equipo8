namespace Proyecto_Pokemon;

public class Pokemon : IPokemon
{
    public string Nombre { get; }
    public int Vida { get; set; }
    public int VidaBase { get; set; }
    public List<IHabilidades> Habilidades { get; }
    public ITipo TipoPrincipal { get; }
    public ITipo TipoSecundario { get; }
    public IHabilidades HabilidadCargando { get; set; }
    public string Estado { get; set; }

    public Pokemon(string nombre, int vida, ITipo tipoPrincipal, ITipo tipoSecundario = null, string estado = null)
    {
        Nombre = nombre;
        Vida = vida;
        VidaBase = Vida;
        TipoPrincipal = tipoPrincipal;
        TipoSecundario = tipoSecundario;
        Habilidades = new List<IHabilidades>();
        HabilidadCargando = null;
        Estado = estado;
    }

    public void AprenderHabilidad(IHabilidades habilidad)
    {
        Habilidades.Add(habilidad);
    }
    
    

}
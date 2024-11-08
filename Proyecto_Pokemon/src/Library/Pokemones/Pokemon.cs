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
    
    // metodo que permite al pokemon aprender las habilidades
    public void AprenderHabilidad(IHabilidades habilidad)
    {
        Habilidades.Add(habilidad);
    }
    
    // metodo que devuelve una lista con las habilidades del pokemon
    public List<IHabilidades> MostrarHabilidades()
    {
        List<IHabilidades> habilidades = new List<IHabilidades>();
        for (int i = 0; i < Habilidades.Count; i++)
        {
            IHabilidades habilidad = Habilidades[i];
            habilidades.Add(habilidad); // añade cada habilidad a la lista que se va a devolver
        }
        return habilidades;
    }

}
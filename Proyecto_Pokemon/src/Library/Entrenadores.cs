namespace Proyecto_Pokemon;

public class Entrenadores
{
    public string Nombre { get; }
    public List<Pokemon> Pokemones { get; }
    public List<Objetos> Mochila { get; }

    public Entrenadores(string nombre, List<Pokemon> pokemones, List<Objetos> mochila = null)
    {
        Nombre = nombre;
        Pokemones = pokemones;
        Mochila = mochila ?? InicializarMochila();
    }
    
    private List<Objetos> InicializarMochila()
    {
        return new List<Objetos>
        {
            new Objetos(TipoObjeto.SuperPocion),
            new Objetos(TipoObjeto.SuperPocion),
            new Objetos(TipoObjeto.SuperPocion),
            new Objetos(TipoObjeto.SuperPocion),
            new Objetos(TipoObjeto.Revivir),
            new Objetos(TipoObjeto.CuraTotal),
            new Objetos(TipoObjeto.CuraTotal)
        };
    }
    
    public void MostrarPokemones()
    {
        for (int i = 0; i < Pokemones.Count; i++)
        {
            var estado = Pokemones[i].Vida > 0 ? "Vivo" : "Debilitado";
            Console.WriteLine($"{i + 1}. {Pokemones[i].Nombre} ({estado}) - Vida: {Pokemones[i].Vida}/{Pokemones[i].VidaBase}");
        }
    }
    
    public bool TienePokemonesVivos()
    {
        return Pokemones.Any(pokemon => pokemon.Vida > 0);
    }
    
    public void MostrarMochila()
    {
        Console.WriteLine("Objetos disponibles:");
        for (int i = 0; i < Mochila.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Mochila[i].Nombre}");
        }
    }
    
}
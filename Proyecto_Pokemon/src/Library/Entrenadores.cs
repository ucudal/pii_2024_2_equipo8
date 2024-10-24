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
        Dictionary<string, int> contadordeObjetos = new Dictionary<string, int>();
        foreach (var objetos in Mochila)
        {
            if (contadordeObjetos.ContainsKey(objetos.Nombre))
            {
                contadordeObjetos[objetos.Nombre]++;
            }
            else
            {
                contadordeObjetos[objetos.Nombre] = 1;
            }
        }
        Console.WriteLine("Objetos disponibles:");
        int i = 1;
        foreach (var objetitos in contadordeObjetos)
        {
            Console.WriteLine($"{i}. {objetitos.Key} ({objetitos.Value}x)");
            i++;
        }
    }
    
}
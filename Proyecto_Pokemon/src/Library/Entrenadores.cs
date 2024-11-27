namespace Proyecto_Pokemon;
/// <summary>
/// 
/// </summary>
public class Entrenadores
{
    /// <summary>
    /// 
    /// </summary>
    public string Nombre { get; }
    /// <summary>
    /// 
    /// </summary>
    public List<Pokemon> Pokemones { get; }
    /// <summary>
    /// 
    /// </summary>
    public int CantidadDePokemones
    {
        get { return Pokemones.Count; }
    }
    /// <summary>
    /// 
    /// </summary>
    public Pokemon PokemonActivo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<Objetos> Mochila { get; } = new List<Objetos>();
    /// <summary>
    /// 
    /// </summary>
    public bool EnBatalla { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Entrenadores(string nombre)
    {
        Nombre = nombre;
        Pokemones = new List<Pokemon>();
        Mochila = InicializarMochila();
        EnBatalla = false;
    }

    // Booleano que indica si un pokemon existe con ese nombre en string
    /// <summary>
    /// 
    /// </summary>
    public bool BuscarPokemon(string nombrePokemon)
    {
        foreach (Pokemon pokemon in Pokemones)
            if (pokemon.Nombre == nombrePokemon)
                return true;
        return false;
    }
    
    // Devolver pokemon según string de nombre, útil para fachada
    /// <summary>
    /// 
    /// </summary>
    public Pokemon BuscarPokemonYGuardar(string nombrePokemon)
    {
        foreach (Pokemon pokemon in Pokemones)
        {
            if (pokemon.Nombre == nombrePokemon)
            {
                return pokemon;
            }
        }
        return null;
    }
    
    // Creación de objetos de mochila para cada entrenador
    /// <summary>
    /// 
    /// </summary>
    private List<Objetos> InicializarMochila()
    {
        return new List<Objetos>
        {
            new SuperPocion(),
            new SuperPocion(),
            new SuperPocion(),
            new SuperPocion(),
            new Revivir(),
            new CuraTotal(),
            new CuraTotal()
        };
        
    }
    
    // Cambio de pokemon activo al previsto, si no es al primero disponible
    /// <summary>
    /// 
    /// </summary>
    public bool FijarPokemonActual(Pokemon? pokemon = null)
    {
        if (pokemon != null)
        {
            if (pokemon.Vida > 0)
            {
                PokemonActivo = pokemon;
                return true;
            }
            return false;
        }
        else
        {
            foreach (Pokemon poke in Pokemones)
            {
                if (poke.Vida > 0)
                {
                    PokemonActivo = poke;
                    return true;
                }
            }
        }
        return false;
    }
    
    // Devuelve pokemones de equipo
    /// <summary>
    /// 
    /// </summary>
    public List<Pokemon> RecibirEquipoPokemon()
    {
        return Pokemones;
    }
    
    // Check booleano de pokemones vivos, útil para batalla. Lógica hecha en entrenadores por srp
    /// <summary>
    /// 
    /// </summary>
    public bool TienePokemonesVivos()
    {
        return Pokemones.Any(pokemon => pokemon.Vida > 0);
    }
    
    // Añadir pokemons a lista de entrenador
    /// <summary>
    /// 
    /// </summary>
    public bool AñadirPokemon(Pokemon pokemon)
    {
        if (Pokemones.Count < 6)
        {
            if (!Pokemones.Contains(pokemon))
            {
                if (Pokemones.Count == 0)
                    FijarPokemonActual(pokemon);
                Pokemones.Add(pokemon);
                return true;
            }
        }
        return false;
    }
    
    // Ver lista de objetos alocados en mochila del entrenador
    /// <summary>
    /// 
    /// </summary>
    public List<Objetos> MostrarMochila()
    {
        Dictionary<string, int> contadordeObjetos = new Dictionary<string, int>();
        List<Objetos> listaObjetosUnicos = new List<Objetos>();
        
        foreach (var objetos in Mochila)
        {
            if (contadordeObjetos.ContainsKey(objetos.Nombre))
            {
                contadordeObjetos[objetos.Nombre]++;
            }
            else
            {
                contadordeObjetos[objetos.Nombre] = 1;
                listaObjetosUnicos.Add(objetos);
            }
        }

        return listaObjetosUnicos;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public List<Objetos> GetItemList()
    {
        return Mochila;
    }
    
    // Método para acceder a objetos desde strings
    /// <summary>
    /// 
    /// </summary>
    public Objetos? BuscarObjeto(string nombreObjeto)
    {
        foreach (Objetos objeto in Mochila)
        {
            if (objeto.Nombre == nombreObjeto)
            {
                return objeto;
            }
        }
        return null;
    }
    
    
}
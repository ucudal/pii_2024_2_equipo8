namespace Proyecto_Pokemon;
/// <summary>
/// Representa un entrenador en el mundo pokemon con un equipo, una mochila y estado de batalla.
/// </summary>
public class Entrenadores
{
    /// <summary>
    /// Define el nombre del entrenador
    /// </summary>
    public string Nombre { get; }
    /// <summary>
    /// Lista de Pokemon del entrenador.
    /// </summary>
    public List<Pokemon> Pokemones { get; }
    /// <summary>
    /// cantidad de pokemon en el equipo del entrenador
    /// </summary>
    public int CantidadDePokemones
    {
        get { return Pokemones.Count; }
    }
    /// <summary>
    /// pokemon que el entrenador tiene actualmente en batalla
    /// </summary>
    public Pokemon PokemonActivo { get; set; }
    /// <summary>
    /// creacion de objetos de mochila para cada entrenador
    /// </summary>
    public List<Objetos> Mochila { get; } = new List<Objetos>();
    /// <summary>
    /// indica si el entrenador esta en batalla
    /// </summary>
    public bool EnBatalla { get; set; }
    /// <summary>
    /// constructor para inicializar el entrenador con nombre, pokemones y mochila
    /// </summary>
    public Entrenadores(string nombre)
    {
        Nombre = nombre;
        Pokemones = new List<Pokemon>();
        Mochila = InicializarMochila();
        EnBatalla = false;
    }

    /// <summary>
    /// Booleano que indica si un pokemon existe con ese nombre en string
    /// </summary>
    public bool BuscarPokemon(string nombrePokemon)
    {
        foreach (Pokemon pokemon in Pokemones)
            if (pokemon.Nombre == nombrePokemon)
                return true;
        return false;
    }
    
    /// <summary>
    /// Devolver pokemon según string de nombre, útil para fachada
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
    
    /// <summary>
    /// Creación de objetos de mochila para cada entrenador
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
            new CuraTotal(),
            new Restaurartodo()
        };
        
    }
    
    /// <summary>
    /// Cambio de pokemon activo al previsto, si no es al primero disponible
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
    
    /// <summary>
    /// Devuelve pokemones de equipo
    /// </summary>
    public List<Pokemon> RecibirEquipoPokemon()
    {
        return Pokemones;
    }
    
    /// <summary>
    /// Check booleano de pokemones vivos, útil para batalla. Lógica hecha en entrenadores por srp
    /// </summary>
    public bool TienePokemonesVivos()
    {
        return Pokemones.Any(pokemon => pokemon.Vida > 0);
    }
    
    /// <summary>
    /// Añadir pokemons a lista de entrenador
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
    
    /// <summary>
    /// Ver lista de objetos alocados en mochila del entrenador
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
    /// devuelve la lista completa de objetos en la mochila
    /// </summary>
    public List<Objetos> GetItemList()
    {
        return Mochila;
    }
    
    /// <summary>
    /// Método para acceder a objetos desde strings
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
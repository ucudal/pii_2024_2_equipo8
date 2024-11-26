namespace Proyecto_Pokemon;

public class Entrenadores
{
    public string Nombre { get; }
    public List<Pokemon> Pokemones { get; }
    public int CantidadDePokemones
    {
        get { return Pokemones.Count; }
    }
    public Pokemon PokemonActivo { get; set; }
    public List<Objetos> Mochila { get; }
    public bool EnBatalla { get; set; }

    public Entrenadores(string nombre)
    {
        Nombre = nombre;
        Pokemones = new List<Pokemon>();
        Mochila = InicializarMochila();
        EnBatalla = false;
    }

    // Booleano que indica si un pokemon existe con ese nombre en string
    public bool BuscarPokemon(string nombrePokemon)
    {
        foreach (Pokemon pokemon in Pokemones)
            if (pokemon.Nombre == nombrePokemon)
                return true;
        return false;
    }
    
    // Devolver pokemon según string de nombre, útil para fachada
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
    public List<Pokemon> RecibirEquipoPokemon()
    {
        return Pokemones;
    }
    
    // Check booleano de pokemones vivos, útil para batalla. Lógica hecha en entrenadores por srp
    public bool TienePokemonesVivos()
    {
        return Pokemones.Any(pokemon => pokemon.Vida > 0);
    }
    
    // Añadir pokemons a lista de entrenador
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
    
    // Método para acceder a objetos desde strings
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
namespace Proyecto_Pokemon;

public class Entrenadores
{
    public string Nombre { get; }
    public List<Pokemon> Pokemones { get;  }
    public List<Objetos> Mochila { get; }
    
    public bool EnBatalla { get; set; }

    public Entrenadores(string nombre, List<Pokemon> pokemones, List<Objetos> mochila = null)
    {
        Nombre = nombre;
        Pokemones = pokemones;
        Mochila = mochila ?? InicializarMochila();
        EnBatalla = false;
    }
    
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
    
    public string MostrarPokemones()
    {
        string pokemones = "";
        for (int i = 0; i < Pokemones.Count; i++)
        {
            var estado = Pokemones[i].Vida > 0 ? "Vivo" : "Debilitado";
            pokemones += ($"{i + 1}. {Pokemones[i].Nombre} ({estado}) - Vida: {Pokemones[i].Vida}/{Pokemones[i].VidaBase}; ");
        }
        return pokemones;
    }
    
    public bool TienePokemonesVivos()
    {
        return Pokemones.Any(pokemon => pokemon.Vida > 0);
    }
    
    public List<string> ObtenerMochila()
    {
        Dictionary<string, int> contadorDeObjetos = new Dictionary<string, int>();
        List<string> listaObjetosUnicos = new List<string>();

        foreach (var objeto in Mochila)
        {
            if (contadorDeObjetos.ContainsKey(objeto.Nombre))
            {
                contadorDeObjetos[objeto.Nombre]++;
            }
            else
            {
                contadorDeObjetos[objeto.Nombre] = 1;
            }
        }

        foreach (var kvp in contadorDeObjetos)
        {
            listaObjetosUnicos.Add($"{kvp.Key} ({kvp.Value}x)");
        }

        return listaObjetosUnicos;
    }

    public string SeleccionarEquipo( List<Pokemon> equipoSeleccionado)
    {
        if (equipoSeleccionado.Count != 6)
        {
            return ("Debes seleccionar exactamente 6 Pokémon.");
        }

        // Asigna los Pokémon seleccionados al equipo del entrenador
        Pokemones.AddRange(equipoSeleccionado);
        return "Equipo seleccionado con exito";
    }
    
}
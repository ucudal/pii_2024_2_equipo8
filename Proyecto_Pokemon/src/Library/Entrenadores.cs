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
            pokemones += pokemones+($"{i + 1}. {Pokemones[i].Nombre} ({estado}) - Vida: {Pokemones[i].Vida}/{Pokemones[i].VidaBase}; ");
        }
        return pokemones;
    }
    
    public bool TienePokemonesVivos()
    {
        return Pokemones.Any(pokemon => pokemon.Vida > 0);
    }
    
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
        
        Console.WriteLine("Objetos disponibles:");
        for (int i = 0; i < listaObjetosUnicos.Count; i++)
        {
            var objeto = listaObjetosUnicos[i];
            Console.WriteLine($"{i + 1}. {objeto.Nombre} ({contadordeObjetos[objeto.Nombre]}x)");
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
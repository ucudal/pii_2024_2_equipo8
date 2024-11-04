namespace Proyecto_Pokemon;

public class Entrenadores
{
    public string Nombre { get; }
    public List<Pokemon> Pokemones { get; }
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
    
}
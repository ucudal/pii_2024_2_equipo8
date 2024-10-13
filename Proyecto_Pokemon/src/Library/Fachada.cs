namespace Proyecto_Pokemon;

public class Fachada
{
    public void MostrarOpciones(Batallas batalla)
    {
        bool opcionvalida = false;
        while (!opcionvalida)
        {
            Console.WriteLine();
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Cambiar Pokémon");
            Console.WriteLine("3. Esquivar");
            string opcion = Console.ReadLine();
            Console.WriteLine();
            switch (opcion)
            {
                case "1":
                    batalla.Atacar();
                    opcionvalida = true;
                    break;
                case "2":
                    batalla.CambiarPokemon();
                    opcionvalida = true;
                    break;
                case "3":
                    batalla.Esquivar();
                    opcionvalida = true;
                    break;
                default:
                    Console.WriteLine("Opción invalida. Ingrese nuevamente");
                    break;
            }
        }
    }
    
    public void EjecutarAtaque(Pokemon atacante, Pokemon defensor, IHabilidades habilidad, bool esquivo)
    {
        double efectividad = habilidad.Tipo.EsEfectivoOPocoEfectivo(defensor.TipoPrincipal);
        int danio = (int)(habilidad.Danio * efectividad);
        if (defensor.TipoSecundario != null)
        {
            efectividad = habilidad.Tipo.EsEfectivoOPocoEfectivo(defensor.TipoSecundario);
            danio = (int)(danio * efectividad);
        }

        Random random = new Random();
        int probabilidad = random.Next(0, 100);
        int precisionfinal = habilidad.Precision;
        if (esquivo)
        {
            precisionfinal -= 30;
        }
        Console.WriteLine();
        if (probabilidad <= precisionfinal)
        {
            defensor.Vida -= danio;
            if (defensor.Vida < 0)
            {
                defensor.Vida = 0;
            }
            Console.WriteLine($"{atacante.Nombre} usó {habilidad.Nombre}, hizo {danio} puntos de daño, la vida actual de {defensor.Nombre} = {defensor.Vida}");
        }
        else
        {
            Console.WriteLine($"{atacante.Nombre} falló el ataque");
        }
    }
    
    public static void SeleccionarEquipo(Entrenadores entrenador, List<Pokemon> todosLosPokemones)
    {
        Console.WriteLine($"{entrenador.Nombre}, selecciona los 6 Pokémon para tu equipo:");
        List<Pokemon> equipo = new List<Pokemon>();

        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"\nElegí el Pokémon {i + 1}:");

            for (int j = 0; j < todosLosPokemones.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {todosLosPokemones[j].Nombre} (HP: {todosLosPokemones[j].Vida}, Tipo: {todosLosPokemones[j].TipoPrincipal.Nombre})");
            }
            Console.WriteLine();

            int eleccion;
            bool eleccionValida = int.TryParse(Console.ReadLine(), out eleccion);
            if (!eleccionValida || eleccion < 1 || eleccion > todosLosPokemones.Count)
            {
                
                Console.WriteLine("La opciión que elegiste no es valido, ingrese de nuevo: ");
                i--;
                continue;
            }
            Pokemon pokemonElegido = todosLosPokemones[eleccion - 1];
            equipo.Add(pokemonElegido);
            Console.WriteLine();
            Console.WriteLine($"Has agregado a {pokemonElegido.Nombre} a tu equipo");
            todosLosPokemones.RemoveAt(eleccion - 1);
        }
        entrenador.Pokemones.AddRange(equipo);
    }

}
namespace Proyecto_Pokemon;

public class Batallas
{
    Fachada fachada = new Fachada();
    private Entrenadores entrenador1;
    private Entrenadores entrenador2;
    private Entrenadores entrenadorActual;
    private Pokemon pokemonActivo1;
    private Pokemon pokemonActivo2;
    private int turno;
    private IHabilidades habilidadCargando = null;
    private bool esquivo;
    public int Turno { get => turno; }
    public Batallas(Entrenadores entrenador1, Entrenadores entrenador2)
    {
        this.entrenador1 = entrenador1;
        this.entrenador2 = entrenador2;
        pokemonActivo1 = entrenador1.Pokemones[0];
        pokemonActivo2 = entrenador2.Pokemones[0];
        entrenadorActual = entrenador1;
        turno = 1;
    }

    public void Iniciar()
    {
        while (entrenador1.TienePokemonesVivos() && entrenador2.TienePokemonesVivos())
        {
            Pokemon atacante = entrenadorActual == entrenador1 ? pokemonActivo1 : pokemonActivo2;
            if (atacante.HabilidadCargando != null)
            {
                Console.WriteLine($"{atacante.Nombre} está preparado para usar {atacante.HabilidadCargando.Nombre}.");
                Atacar();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Turno {turno}: {atacante.Nombre} de {entrenadorActual.Nombre} elija su proximo movimiento");
                fachada.MostrarOpciones(this);
            }

            turno++;
            CambiarTurno();
        }
    }

    public void Atacar()
    {
        Pokemon atacante = entrenadorActual == entrenador1 ? pokemonActivo1 : pokemonActivo2;
        Pokemon defensor = entrenadorActual == entrenador1 ? pokemonActivo2 : pokemonActivo1;
        if (atacante.HabilidadCargando != null)
        {
            fachada.EjecutarAtaque(atacante, defensor, atacante.HabilidadCargando, esquivo);
            atacante.HabilidadCargando = null;
            return;
        }

        Console.WriteLine($"{entrenadorActual.Nombre}, elige una habilidad para atacar:");
        atacante.MostrarHabilidades();
        int habilidadElegida = Convert.ToInt32(Console.ReadLine()) - 1;
        while (habilidadElegida > 3 || habilidadElegida < 0)
        {
            Console.WriteLine("La habilidad que queres usar no existe, ingreselo de nuevo: ");
            atacante.MostrarHabilidades();
            habilidadElegida = Convert.ToInt32(Console.ReadLine()) - 1;
        }

        IHabilidades habilidad = atacante.Habilidades[habilidadElegida];

        while (habilidad.PP <= 0)
        {
            Console.WriteLine($"La habilidad {habilidad.Nombre} no tiene PP suficientes, elige otra habilidad:");
            atacante.MostrarHabilidades();
            habilidadElegida = Convert.ToInt32(Console.ReadLine()) - 1;
            habilidad = atacante.Habilidades[habilidadElegida];
        }

        habilidad.PP--;

        if (habilidad.EsDobleTurno)
        {
            Console.WriteLine($"{atacante.Nombre} está cargando la habilidad {habilidad.Nombre}...");
            atacante.HabilidadCargando = habilidad;
            return;
        }

        fachada.EjecutarAtaque(atacante, defensor, habilidad, esquivo);
        
        if (defensor.Vida <= 0)
        {
            CambiarTurno();
            if (!entrenadorActual.TienePokemonesVivos())
            {
                CambiarTurno();
                Console.WriteLine($"{entrenadorActual.Nombre} GANÓ LA BATALLA");
            }
            else
            {
                Console.WriteLine(
                    $"El {defensor.Nombre} de {entrenadorActual.Nombre} fue derrotado, cambia el pokemon");
                CambiarPokemon();
            }
        }
    }


    public void Esquivar()
    {
        Pokemon atacante = entrenadorActual == entrenador1 ? pokemonActivo1 : pokemonActivo2;
        esquivo = true;
        Console.WriteLine($"{atacante.Nombre} de {entrenadorActual.Nombre} está preparado para esquivar el proximo movimiento");
    }


    public void CambiarPokemon()
    {
        Console.WriteLine($"{entrenadorActual.Nombre}, elegí el Pokemon que quieras usar:");
        entrenadorActual.MostrarPokemones();
        int indicePokemon = Convert.ToInt32(Console.ReadLine()) - 1;
        while (indicePokemon >= entrenadorActual.Pokemones.Count || indicePokemon < 0)
        {
            Console.WriteLine("El pokemon que queres usar no existe, ingrese el cambio nuevamente: ");
            entrenadorActual.MostrarPokemones();
            indicePokemon = Convert.ToInt32(Console.ReadLine()) - 1;
        }

        if (entrenadorActual.Pokemones[indicePokemon].Vida > 0)
        {
            if (entrenadorActual == entrenador1)
            {
                pokemonActivo1 = entrenadorActual.Pokemones[indicePokemon];
            }
            else
            {
                pokemonActivo2 = entrenadorActual.Pokemones[indicePokemon];
            }

            Console.WriteLine($"{entrenadorActual.Nombre} cambió a {entrenadorActual.Pokemones[indicePokemon].Nombre}");
        }
        else
        {
            Console.WriteLine("No puedes elegir un Pokémon debilitado.");
            CambiarPokemon();
        }
    }

    private void CambiarTurno()
    {
        entrenadorActual = entrenadorActual == entrenador1 ? entrenador2 : entrenador1;
    }
}
namespace Proyecto_Pokemon;
using System;

public class Batalla
{
    public Entrenador Entrenador1 { get; private set; }
    public Entrenador Entrenador2 { get; private set; }
    public int Turno { get;  set; }
    private bool batallaFinalizada;

    public Batalla(Entrenador entrenador1, Entrenador entrenador2)
    {
        Entrenador1 = entrenador1;
        Entrenador2 = entrenador2;
        Turno = 1; // Comienza el entrenador 1
        batallaFinalizada = false;
    }

    public void IniciarBatalla()
    {
        Console.WriteLine($"¡Comienza la batalla entre {Entrenador1.Nombre} y {Entrenador2.Nombre}!");
    }

    public void ImprimirTurnoActual()
    {
        if (Turno % 2 != 0)
        {
            Console.WriteLine($"Es el turno de {Entrenador1.Nombre}");
        }
        else
        {
            Console.WriteLine($"Es el turno de {Entrenador2.Nombre}");
        }
    }

    public void Atacar(Entrenador atacante, Entrenador defensor, Pokemon atacantePokemon, Pokemon defensorPokemon, string ataque)
    {
        if (!batallaFinalizada)
        {
            Console.WriteLine($"{atacante.Nombre} ordena a {atacantePokemon.Nombre} usar {ataque} contra {defensorPokemon.Nombre}");
            
            // Calcular efectividad de ataque acá
            
            // Chequear si el defensor ha sido derrotado
            if (defensorPokemon.Vida <= 0)
            {
                Console.WriteLine($"{defensorPokemon.Nombre} ha sido derrotado.");
            }

            VerificarGanador();
            if (!batallaFinalizada)
            {
                TerminarTurno();
            }
        }
    }

    public void TerminarTurno()
    {
        Turno++;
        ImprimirTurnoActual();
    }

    public void AbandonarBatalla(Entrenador entrenador)
    {
        batallaFinalizada = true;
        Console.WriteLine($"{entrenador.Nombre} ha abandonado la batalla. ¡El otro entrenador es el ganador!");
    }
    
    private void VerificarGanador()
    {
        if (Entrenador1.ObtenerPokemonsDisponibles().Count == 0 || Entrenador2.ObtenerPokemonsDisponibles().Count == 0)
        {
            batallaFinalizada = true;
            ImprimirGanador();
        }
    }
    
    public void ImprimirGanador()
    {
        if (!batallaFinalizada)
        {
            Console.WriteLine("La batalla no ha terminado todavía.");
        }
        else
        {
            Entrenador ganador = DeterminarGanador();
            if (ganador != null)
            {
                Console.WriteLine($"La batalla ha terminado. ¡El ganador es {ganador.Nombre}!");
            }
            else
            {
                Console.WriteLine("La batalla ha terminado en empate.");
            }
        }
    }

    private Entrenador DeterminarGanador()
    {
        // Usamos el método ObtenerPokemonsDisponibles para contar los Pokémon vivos
        int pokemonsConVidaEntrenador1 = Entrenador1.ObtenerPokemonsDisponibles().Count;
        int pokemonsConVidaEntrenador2 = Entrenador2.ObtenerPokemonsDisponibles().Count;

        // Comparar las cantidades y retornar al entrenador con más Pokémon con vida
        if (pokemonsConVidaEntrenador1 > pokemonsConVidaEntrenador2)
        {
            return Entrenador1;
        }
        else if (pokemonsConVidaEntrenador2 > pokemonsConVidaEntrenador1)
        {
            return Entrenador2;
        }
        else
        {
            return null; // Empate
        }
    }
}
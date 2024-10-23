using System.ComponentModel.Design;

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

    public int Turno
    {
        get => turno;
    }

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
        Random random = new Random();
        int turnos_noqueado = 4;
        while (entrenador1.TienePokemonesVivos() && entrenador2.TienePokemonesVivos())
        {
            Pokemon atacante = entrenadorActual == entrenador1 ? pokemonActivo1 : pokemonActivo2;
            if (atacante.Estado != null)
            {
                switch (atacante.Estado)
                {
                    case "envenenado":
                        atacante.Vida -= (int)(atacante.VidaBase * 0.05);
                        Console.WriteLine(
                            $"{atacante.Nombre} pierde vida por envenenamiento. Vida restante: {atacante.Vida} / {atacante.VidaBase}");
                        if (atacante.Vida <= 0)
                        {
                            Console.WriteLine($"{atacante.Nombre} fue derrotado por el veneno!");
                            CambiarPokemon();
                            CambiarTurno();
                            continue;
                        }

                        break;
                    case "noqueado":
                        if (random.Next(1, 5) < turnos_noqueado)
                        {
                            Console.WriteLine($"{atacante.Nombre} se ha recuperado del noqueo y puede volver a atacar.");
                            turnos_noqueado = 4;
                            atacante.Estado = null;
                        }
                        else
                        {
                            Console.WriteLine($"{atacante.Nombre} está noqueado. No se puede mover.");
                            turnos_noqueado--;
                            CambiarTurno();
                        }

                        break;
                    case "quemado":
                        atacante.Vida -= (int)(atacante.VidaBase * 0.10);
                        Console.WriteLine($"{atacante.Nombre} está quemado y pierde {(int)(atacante.VidaBase * 0.10)} HP. Vida restante: {atacante.Vida} / {atacante.VidaBase}");
                        if (atacante.Vida <= 0)
                        {
                            Console.WriteLine($"{atacante.Nombre} fue derrotado por la quemadura!");
                            CambiarPokemon();
                            CambiarTurno();
                            continue;
                        }
                        break;
                }
            }

            if (atacante.Estado != "noqueado")
            {
                if (atacante.HabilidadCargando != null)
                {
                    Console.WriteLine("EFECTO");
                    Console.WriteLine(
                        $"{atacante.Nombre} está preparado para usar {atacante.HabilidadCargando.Nombre}.");
                    Atacar();
                }
                else
                {
                    Console.WriteLine("NOEFECTO");
                    Console.WriteLine();
                    Console.WriteLine(
                        $"Turno {turno}: {atacante.Nombre} de {entrenadorActual.Nombre} elija su proximo movimiento");
                    fachada.MostrarOpciones(this);
                    CambiarTurno();
                }
            }
            turno++;
        }
    }

    public void Atacar()
    {
        Random random = new Random();
        Pokemon atacante = entrenadorActual == entrenador1 ? pokemonActivo1 : pokemonActivo2;
        Pokemon defensor = entrenadorActual == entrenador1 ? pokemonActivo2 : pokemonActivo1;

        if (atacante.HabilidadCargando != null)
        {
            if (atacante.Estado == "paralizado" && random.Next(0, 100) < 20)
            {
                Console.WriteLine($"{atacante.Nombre} está paralizado. No se puede mover.");
            }
            else
            {
                fachada.EjecutarAtaque(atacante, defensor, atacante.HabilidadCargando, esquivo);
                atacante.HabilidadCargando = null;
                CambiarTurno();
                return;
            }
        }

        Console.WriteLine($"{entrenadorActual.Nombre}, elige una habilidad para atacar (0 para VOLVER):");
        atacante.MostrarHabilidades();
        int habilidadElegida = Convert.ToInt32(Console.ReadLine()) - 1;
        if (habilidadElegida == -1)
        {
            fachada.MostrarOpciones(this);
        }

        while (habilidadElegida > 3 || habilidadElegida < -1)
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

        if (atacante.Estado == "paralizado" && random.Next(0, 100) < 20)
        {
            Console.WriteLine($"{atacante.Nombre} está paralizado. No se puede mover.");
            return;
        }

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
        Console.WriteLine(
            $"{atacante.Nombre} de {entrenadorActual.Nombre} está preparado para esquivar el proximo movimiento");
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

    public void UsarMochila()
    {
        Pokemon atacante = entrenadorActual == entrenador1 ? pokemonActivo1 : pokemonActivo2;
        Console.WriteLine($"{entrenadorActual.Nombre}, elegí el objeto que deseas usar (0 para VOLVER):");
        entrenadorActual.MostrarMochila();
        int objetoElegido = Convert.ToInt32(Console.ReadLine()) - 1;

        if (objetoElegido == -1)
        {
            fachada.MostrarOpciones(this);
        }

        while (objetoElegido >= entrenadorActual.Mochila.Count || objetoElegido < -1)
        {
            Console.WriteLine("El objeto que querés usar no existe, ingresa el numero nuevamente: ");
            entrenadorActual.MostrarMochila();
            objetoElegido = Convert.ToInt32(Console.ReadLine()) - 1;
        }

        Objetos objeto = entrenadorActual.Mochila[objetoElegido];
        objeto.Usar(atacante, entrenadorActual);
        entrenadorActual.Mochila.RemoveAt(objetoElegido);
    }
    
    private void CambiarTurno()
    {
        entrenadorActual = entrenadorActual == entrenador1 ? entrenador2 : entrenador1;
    }

    public void VerVida() 
    {
        Console.WriteLine($"Pokémons de {entrenador1.Nombre}:");
        entrenador1.MostrarPokemones();
        Console.WriteLine($"Pokémons de {entrenador2.Nombre}:");
        entrenador2.MostrarPokemones();
        
    }
}
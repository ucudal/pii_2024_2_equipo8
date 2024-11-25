using System;
using System.Collections.Generic;

namespace Proyecto_Pokemon
{
    public class DemoConsola
    {
        private Fachada fachada = Fachada.Instance;
        

        public void IniciarJuego()
        {
            // Inicializar entrenadores
            Console.WriteLine("Ingrese el nombre del Entrenador 1:");
            string nombre1 = Console.ReadLine();
            fachada.entrenador1 = new Entrenadores(nombre1, new List<Pokemon>());

            Console.WriteLine("Ingrese el nombre del Entrenador 2:");
            string nombre2 = Console.ReadLine();
            fachada.entrenador2 = new Entrenadores(nombre2, new List<Pokemon>());

            // Seleccionar equipos
            LogicaDePokemones logicaDePokemones = new LogicaDePokemones();
            List<Pokemon> todosLosPokemones = logicaDePokemones.InicializarPokemones();

            List<Pokemon> equipo1 = SeleccionarEquipo(fachada.entrenador1, todosLosPokemones);
            List<Pokemon> equipo2 = SeleccionarEquipo(fachada.entrenador2, todosLosPokemones);


            fachada.entrenador1.Pokemones.AddRange(equipo1);
            fachada.entrenador2.Pokemones.AddRange(equipo2);

            // Unirse a la lista de espera
            fachada.UnirseALaListaDeEspera(fachada.entrenador1);
            fachada.UnirseALaListaDeEspera(fachada.entrenador2);

            // Iniciar batalla
            fachada.IniciarBatalla(fachada.entrenador1,fachada.entrenador2);

            // Ciclo principal del juego
            while (true)
            {
                Console.WriteLine(fachada.EsTurnoDe());
                MostrarOpciones();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Atacar
                        Console.WriteLine(fachada.MostrarHabilidades());
                        Console.WriteLine("Elige una habilidad:");
                        int indiceHabilidad = int.Parse(Console.ReadLine()) - 1;
                        string resultadoAtaque = fachada.EjecutarAtaque(indiceHabilidad);
                        Console.WriteLine(resultadoAtaque);
                        if (resultadoAtaque.Contains("ha sido debilitado"))
                        {
                            // En este punto ya se cambió de turno, por lo que defensor es actual.
                            Entrenadores entrenadorDefensor = fachada.batallaActual.entrenadorActual;
                            SolicitarCambioPokemon(entrenadorDefensor);
                        }
                        break;
                    case "2":
                        // Cambiar Pokémon
                        Console.WriteLine(fachada.MostrarPokemones(fachada.batallaActual.entrenadorActual));
                        Console.WriteLine("Elige el Pokémon al que quieres cambiar:");
                        Console.WriteLine(fachada.EsTurnoDe());
                        int indicePokemon = int.Parse(Console.ReadLine()) - 1;
                        string resultadoCambio = fachada.CambiarPokemon(indicePokemon);
                        Console.WriteLine(resultadoCambio);
                        break;
                    case "3":
                        // Usar Mochila
                        List<string> mochila = fachada.batallaActual.entrenadorActual.ObtenerMochila();
                        for (int i = 0; i < mochila.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {mochila[i]}");
                        }
                        Console.WriteLine("Elige el objeto que quieres usar:");
                        int indiceObjeto = int.Parse(Console.ReadLine()) - 1;

                        // Si es Revivir, preguntar por el Pokémon
                        string objetoNombre = fachada.batallaActual.entrenadorActual.Mochila[indiceObjeto].Nombre;
                        if (objetoNombre == "Revivir")
                        {
                            Console.WriteLine("Elige el Pokémon que quieres revivir:");
                            Console.WriteLine(fachada.MostrarPokemones(fachada.batallaActual.entrenadorActual));
                            int indicePokemonRevivir = int.Parse(Console.ReadLine()) - 1;
                            string resultadoMochila = fachada.UsarMochila(indiceObjeto, indicePokemonRevivir);
                            Console.WriteLine(resultadoMochila);
                        }
                        else
                        {
                            string resultadoMochila = fachada.UsarMochila(indiceObjeto);
                            Console.WriteLine(resultadoMochila);
                        }
                        break;
                    case "4":
                        // Esquivar
                        fachada.Esquivar();
                        Console.WriteLine("Te preparas para esquivar el próximo ataque.");
                        fachada.batallaActual.CambiarTurno();
                        break;
                    case "5":
                        // Ver vida de los Pokémon
                        Console.WriteLine(fachada.VerVida());
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                        break;
                }

                // Verificar si la batalla ha terminado
                string finBatalla = fachada.CheckFinBatalla();
                if (finBatalla != "La batalla aún no ha finalizado")
                {
                    Console.WriteLine(finBatalla);
                    break;
                }
            }
        }

        public void MostrarOpciones()
        {
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Cambiar Pokémon");
            Console.WriteLine("3. Usar Mochila");
            Console.WriteLine("4. Esquivar");
            Console.WriteLine("5. Ver vida de los Pokémon");
            Console.WriteLine("Elige una opción:");
        }

        public List<Pokemon> SeleccionarEquipo(Entrenadores entrenador, List<Pokemon> todosLosPokemones)
        {
            Console.WriteLine($"{entrenador.Nombre}, selecciona los 6 Pokémon para tu equipo:");
            List<Pokemon> equipoSeleccionado = new List<Pokemon>();

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"\nElige el Pokémon {i + 1}:");

                for (int j = 0; j < todosLosPokemones.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {todosLosPokemones[j].Nombre} (HP: {todosLosPokemones[j].Vida}, Tipo: {todosLosPokemones[j].TipoPrincipal.Nombre})");
                }

                int eleccion;
                bool eleccionValida = int.TryParse(Console.ReadLine(), out eleccion);
                if (!eleccionValida || eleccion < 1 || eleccion > todosLosPokemones.Count)
                {
                    Console.WriteLine("La opción que elegiste no es válida, ingrese de nuevo:");
                    i--;  // Repetir la selección de Pokémon
                    continue;
                }

                Pokemon pokemonElegido = todosLosPokemones[eleccion - 1];
                equipoSeleccionado.Add(pokemonElegido);
                Console.WriteLine($"Has agregado a {pokemonElegido.Nombre} a tu equipo");

                todosLosPokemones.RemoveAt(eleccion - 1);
            }

            return equipoSeleccionado;
        }
        public void SolicitarCambioPokemon(Entrenadores entrenador)
        
        {
            if (!entrenador.TienePokemonesVivos())
            {
                Console.WriteLine($"{entrenador.Nombre} no tiene más Pokémon vivos. ¡{(entrenador == fachada.entrenador1 ? fachada.entrenador2.Nombre : fachada.entrenador1.Nombre)} ha ganado la batalla!");
                // Terminar la batalla o manejar el fin del juego
                Environment.Exit(0); // O maneja el fin del juego adecuadamente
            }
            Console.WriteLine($"{entrenador.Nombre}, tu Pokémon ha sido derrotado. Debes elegir un nuevo Pokémon.");

            Console.WriteLine(entrenador.MostrarPokemones());

            int indicePokemon = int.Parse(Console.ReadLine()) - 1;

            string resultadoCambio = fachada.CambiarPokemon(indicePokemon);
            
            Console.WriteLine(resultadoCambio);
            if (resultadoCambio == "No puedes elegir un Pokémon debilitado." || resultadoCambio == "El Pokémon que elegiste no existe. Inténtalo de nuevo.")
            {
                SolicitarCambioPokemon(entrenador);
            }
        }

    }
}

using System;
using System.Collections.Generic;

namespace Proyecto_Pokemon
{
    public class DemoConsola
    {
        private Fachada fachada = new Fachada();
        private Entrenadores entrenador1;
        private Entrenadores entrenador2;

        public void IniciarJuego()
        {
            // Inicializar entrenadores
            Console.WriteLine("Ingrese el nombre del Entrenador 1:");
            string nombre1 = Console.ReadLine();
            entrenador1 = new Entrenadores(nombre1, new List<Pokemon>());

            Console.WriteLine("Ingrese el nombre del Entrenador 2:");
            string nombre2 = Console.ReadLine();
            entrenador2 = new Entrenadores(nombre2, new List<Pokemon>());

            // Seleccionar equipos
            LogicaDePokemones logicaDePokemones = new LogicaDePokemones();
            List<Pokemon> todosLosPokemones = logicaDePokemones.InicializarPokemones();

            List<Pokemon> equipo1 = SeleccionarEquipo(entrenador1, todosLosPokemones);
            List<Pokemon> equipo2 = SeleccionarEquipo(entrenador2, todosLosPokemones);


            entrenador1.Pokemones.AddRange(equipo1);
            entrenador2.Pokemones.AddRange(equipo2);

            // Unirse a la lista de espera
            fachada.UnirseALaListaDeEspera(entrenador1);
            fachada.UnirseALaListaDeEspera(entrenador2);

            // Iniciar batalla
            fachada.IniciarBatalla(entrenador1);

            // Ciclo principal del juego
            while (entrenador1.TienePokemonesVivos() && entrenador2.TienePokemonesVivos())
            {
                Pokemon atacante = fachada.ObtenerPokemonActivo();
                Entrenadores entrenadorActual = fachada.batallaActual.entrenadorActual;
                if (atacante.Estado != null)
                {
                    switch (atacante.Estado)
                    {
                        case "envenenado":
                            atacante.Vida -= (int)(atacante.VidaBase * 0.05);
                            Console.WriteLine(
                                $"{atacante.Nombre} pierde vida por envenenamiento. Vida restante: {atacante.Vida}/{atacante.VidaBase}");
                            if (atacante.Vida <= 0)
                            {
                                atacante.Vida = 0;
                                Console.WriteLine($"{atacante.Nombre} fue derrotado por el veneno.");
                                SolicitarCambioPokemon(entrenadorActual);
                                fachada.batallaActual.CambiarTurno();
                                continue;
                            }

                            break;
                        case "quemado":
                            atacante.Vida -= (int)(atacante.VidaBase * 0.10);
                            Console.WriteLine(
                                $"{atacante.Nombre} pierde vida por quemadura. Vida restante: {atacante.Vida}/{atacante.VidaBase}");
                            if (atacante.Vida <= 0)
                            {
                                atacante.Vida = 0;
                                Console.WriteLine($"{atacante.Nombre} fue derrotado por la quemadura.");
                                SolicitarCambioPokemon(entrenadorActual);
                                fachada.batallaActual.CambiarTurno();
                                continue;
                            }

                            break;
                        case "noqueado":
                            Random random = new Random();
                            int turnosNoqueado = 4;
                            if (random.Next(1, 5) > turnosNoqueado)
                            {
                                Console.WriteLine($"{atacante.Nombre} se recuperó del noqueo.");
                                atacante.Estado = null;
                            }
                            else
                            {
                                Console.WriteLine($"{atacante.Nombre} está noqueado y no puede atacar.");
                                fachada.batallaActual.CambiarTurno();
                                turnosNoqueado--;
                                continue;
                            }

                            break;
                        case "paralisis":
                            Random randomParalizado = new Random();
                            bool noPuedeAtacar = randomParalizado.Next(1, 101) <= 25;
                            if (noPuedeAtacar)
                            {
                                Console.WriteLine($"{atacante.Nombre} está paralizado. No se puede mover. (Como en los juegos Jaja)");
                                fachada.batallaActual.CambiarTurno();
                                continue;
                            }
                            break;
                    }
                }

                if (atacante.HabilidadCargando != null)
                {
                    Console.WriteLine($"{atacante.Nombre} usa {atacante.HabilidadCargando.Nombre}.");
                    string resultado = fachada.EjecutarAtaqueCargando();
                    Console.WriteLine(resultado);
                }
                else
                {
                    Console.WriteLine(fachada.EsTurnoDe());
                    MostrarOpciones();
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            // Atacar
                            if (atacante.Estado == "paralizado")
                            {
                                Random randomParalizado = new Random();
                                bool noPuedeAtacar = randomParalizado.Next(1, 101) <= 25;
                                if (noPuedeAtacar)
                                {
                                    Console.WriteLine($"{atacante.Nombre} está paralizado y no puede atacar.");
                                    fachada.batallaActual.CambiarTurno();
                                    break;
                                }
                            }
                            Console.WriteLine(fachada.MostrarHabilidades());
                            Console.WriteLine("Elige una habilidad:");
                            int indiceHabilidad = int.Parse(Console.ReadLine()) - 1;
                            string resultadoAtaque = fachada.EjecutarAtaque(indiceHabilidad);
                            Console.WriteLine(resultadoAtaque);
                            if (resultadoAtaque.Contains("ha sido debilitado"))
                            {
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
            string mensajeFinal = fachada.CheckFinBatalla();
            Console.WriteLine(mensajeFinal);
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
                    i--;
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
                Console.WriteLine($"{entrenador.Nombre} no tiene más Pokémon vivos. ¡{(entrenador == entrenador1 ? entrenador2.Nombre : entrenador1.Nombre)} ha ganado la batalla!");
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

using System;
using System.Collections.Generic;

namespace Proyecto_Pokemon;
public class DemoConsola
{
        public static void MostrarOpciones(Batallas batalla)
        {
            bool opcionvalida = false;
            while (!opcionvalida)
            {
                Console.WriteLine();
                Console.WriteLine("1. ATACAR");
                Console.WriteLine("2. CAMBIAR POKEMON");
                Console.WriteLine("3. MOCHILA");
                Console.WriteLine("4. ESQUIVAR");
                Console.WriteLine("5. VIDA POKEMONES");

                string opcion = Console.ReadLine();
                Console.WriteLine();
                switch (opcion)
                {
                    case "1":
                        batalla.Atacar();
                        opcionvalida = true;
                        break;
                    case "2":
                        CambiarPokemon();
                        opcionvalida = true;
                        break;
                    case "3":
                        UsarMochila();
                        opcionvalida = true;
                        break;
                    case "4":
                        batalla.Esquivar();
                        opcionvalida = true;
                        break;
                    case "5":
                        VerVida();
                        break;
                    default:
                        Console.WriteLine("Opción invalida. Ingrese nuevamente");
                        break;
                }
            }
        }
        
        public static List<Pokemon> SeleccionarEquipo(Entrenadores entrenador,List<Pokemon> todosLosPokemones)
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
}
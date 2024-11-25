using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Proyecto_Pokemon
{
    /// <summary>
    /// Esta clase implementa el comando 'selectteam' del bot. Este comando permite
    /// al jugador seleccionar su equipo de Pokémon para la batalla.
    /// </summary>
    public class SelectTeamCommand : ModuleBase<SocketCommandContext>
    {
        [Command("selectteam")]
        [Summary("Permite al jugador seleccionar su equipo de Pokémon para la batalla.")]
        public async Task ExecuteAsync([Remainder][Summary("Lista de nombres de Pokémon, separados por comas")] string pokemonNames = null)
        {
            string displayName = CommandHelper.GetDisplayName(Context);

            // Obtener o crear el entrenador correspondiente al usuario
            Entrenadores entrenador = Fachada.Instance.GetEntrenadorPorNombre(displayName);
            if (entrenador == null)
            {
                // Si el entrenador no existe, crearlo y agregarlo a la fachada
                entrenador = new Entrenadores(displayName, new List<Pokemon>());
                //Fachada.Instance.AgregarEntrenador(entrenador);
            }

            if (string.IsNullOrEmpty(pokemonNames))
            {
                // Construir el mensaje con la lista de Pokémon
                string mensaje = "Lista de Pokémon disponibles:\n";
                foreach (var pokemon in Fachada.Instance.InicializarPokemons())
                {
                    mensaje += $"- {pokemon.Nombre}\n";
                }

                // Enviar el mensaje al canal donde se ejecutó el comando
                await ReplyAsync(mensaje);

                // Recordar al usuario cómo usar el comando
                await ReplyAsync("Debes proporcionar una lista de nombres de Pokémon separados por comas. Ejemplo: !selectteam Pikachu,Charizard,Blastoise");
                return;
            }

            // Separar los nombres de los Pokémon
            string[] pokemonNameArray = pokemonNames.Split(',');

            if (pokemonNameArray.Length != 6)
            {
                await ReplyAsync("Debes seleccionar exactamente 6 Pokémon para tu equipo.");
                return;
            }

            // Obtener la lista de todos los Pokémon disponibles
            List<Pokemon> todosLosPokemones = Fachada.Instance.InicializarPokemons();

            List<Pokemon> equipoSeleccionado = new List<Pokemon>();

            foreach (string nombrePokemon in pokemonNameArray)
            {
                string nombre = nombrePokemon.Trim();
                Pokemon pokemonElegido = todosLosPokemones.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

                if (pokemonElegido != null)
                {
                    
                    equipoSeleccionado.Add(pokemonElegido);
                }
                else
                {
                    await ReplyAsync($"El Pokémon '{nombre}' no existe o no está disponible.");
                    return;
                }
            }

            // Asignar el equipo al entrenador
            entrenador.Pokemones.AddRange(equipoSeleccionado);

            await ReplyAsync($"{displayName}, has seleccionado tu equipo exitosamente.");

            // Mostrar el equipo seleccionado
            string mensajeEquipo = "Tu equipo es:\n";
            foreach (var poke in equipoSeleccionado)
            {
                mensajeEquipo += $"- {poke.Nombre}\n";
            }
            await ReplyAsync(mensajeEquipo);
        }
    }
}

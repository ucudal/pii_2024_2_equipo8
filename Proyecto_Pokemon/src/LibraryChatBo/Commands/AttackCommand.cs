using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using System.Linq;

namespace Proyecto_Pokemon
{
    public class AttackCommand : ModuleBase<SocketCommandContext>
    {
        [Command("atacar")]
        [Summary("Permite al jugador atacar usando una habilidad.")]
        public async Task ExecuteAsync([Remainder][Summary("Número de la habilidad a usar")] string habilidadInput = null)
        {
            string displayName = CommandHelper.GetDisplayName(Context);

            // Obtener el entrenador actual
            Entrenadores entrenador = Fachada.Instance.GetEntrenadorPorNombre(displayName);
            if (entrenador == null)
            {
                await ReplyAsync($"{displayName}, no estás registrado. Por favor, selecciona tu equipo usando `!selectteam`.");
                return;
            }

            // Verificar si es el turno del entrenador
            if (Fachada.Instance.EsTurnoDe() != displayName )
            {
                await ReplyAsync($"{displayName}, no es tu turno.");
                return;
            }

            // Obtener las habilidades del Pokémon activo
            string habilidades = Fachada.Instance.MostrarHabilidades();

            if (habilidades == null )
            {
                await ReplyAsync("No se encontraron habilidades para tu Pokémon activo.");
                return;
            }

            // Si el usuario no proporcionó la habilidad, mostrar la lista
            if (string.IsNullOrEmpty(habilidadInput))
            {
                string mensajeHabilidades = "Tus habilidades disponibles son:\n";
                
                mensajeHabilidades += Fachada.Instance.MostrarHabilidades();
                mensajeHabilidades += "Usa `!atacar NombreHabilidad` o `!atacar NúmeroHabilidad` para atacar.";
                await ReplyAsync(mensajeHabilidades);
                return;
            }


            int indiceHabilidad;
            bool exito = Int32.TryParse(habilidadInput, out indiceHabilidad);
            if (exito)
            {
                // exito
                
            }
            else
            {
                await ReplyAsync($"Indice no valido de habilidad.");
                return;
            }

            // Ejecutar el ataque
            string resultadoAtaque = Fachada.Instance.EjecutarAtaque(indiceHabilidad);

            // Enviar el resultado al canal
            await ReplyAsync(resultadoAtaque);

            // Verificar si el Pokémon defensor ha sido derrotado
            if (resultadoAtaque.Contains("ha sido derrotado"))
            {
                // Obtener el entrenador defensor
                Entrenadores entrenadorDefensor = Fachada.Instance.ObtenerEntrenadorActual();

                // Verificar si el entrenador defensor tiene Pokémon vivos
                if (entrenadorDefensor.TienePokemonesVivos())
                {
                    // Solicitar al entrenador defensor que cambie de Pokémon
                    await SolicitarCambioPokemon(entrenadorDefensor);
                }
                else
                {
                    // La batalla ha terminado
                    await ReplyAsync($"{entrenador.Nombre} ha ganado la batalla!");
                    // Aquí puedes manejar el fin de la batalla
                }
            }
        }

        // Método para solicitar al entrenador que cambie de Pokémon
        private async Task SolicitarCambioPokemon(Entrenadores entrenador)
        {
            // Obtener las opciones de Pokémon disponibles
            var pokemonesVivos = entrenador.Pokemones.Where(p => p.Vida > 0).ToList();

            if (pokemonesVivos.Count == 0)
            {
                await ReplyAsync($"{entrenador.Nombre} no tiene más Pokémon vivos.");
                return;
            }

            // Enviar mensaje al entrenador defensor
            string mensaje = $"{entrenador.Nombre}, tu Pokémon ha sido derrotado. Debes elegir un nuevo Pokémon.\n";
            for (int i = 0; i < pokemonesVivos.Count; i++)
            {
                mensaje += $"{i + 1}. {pokemonesVivos[i].Nombre} (HP: {pokemonesVivos[i].Vida}/{pokemonesVivos[i].VidaBase})\n";
            }
            mensaje += "Usa `!cambiarpokemon NombrePokemon` o `!cambiarpokemon NúmeroPokemon` para cambiar.";

            // Enviar mensaje al entrenador defensor 
            await ReplyAsync(mensaje);
        }
    }
}

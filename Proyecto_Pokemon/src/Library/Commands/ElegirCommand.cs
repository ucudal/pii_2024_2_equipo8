using Discord.Commands;
namespace Proyecto_Pokemon;

/// <summary>
/// Esta clase implementa el comando 'elegir' del bot.
/// </summary>
public class ElegirCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Agregar pokemon al equipo.
    /// </summary>
    [Command("elegir")]
    [Summary(
        """
        Agrega al equipo del jugador el Pokemon seleccionado.
        Si no se logra agregar envía un mensaje avisando al usuario.
        """)]
    public async Task ExecuteAsync(
        [Remainder] [Summary("Nombre del pokemon.")]
        string pokemonName)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result;
        result = Fachada.SeleccionarEquipo(displayName, pokemonName);
        await ReplyAsync(result);

    }
}
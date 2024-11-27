using Discord.Commands;
namespace Proyecto_Pokemon;

/// <summary>
/// Esta clase se encarga de agregar a tu equipo el pokemon que selecciones
/// </summary>
public class ElegirCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Agregar pokemon al equipo.
    /// </summary>
    [Command("elegir")]
    [Summary("Agrega al equipo del jugador el Pokemon que selecciones")]
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
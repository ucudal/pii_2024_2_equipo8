using Discord.Commands;

namespace Proyecto_Pokemon;

/// <summary>
/// comando para ver el estado de los pokemones
/// </summary>
public class VerVidaCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra el estado de los pokemones .
    /// </summary>
    [Command("verVida")]
    [Summary("Devuelve la vida de los pokemones y sus detalles")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync(
        [Remainder] [Summary("Display name del oponente, opcional")]
        string? opponentDisplayName = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result;
        result = Fachada.VerPokemones(displayName, opponentDisplayName);

        await ReplyAsync(result);
    }
}
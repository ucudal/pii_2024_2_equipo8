using Discord.Commands;

namespace Proyecto_Pokemon;

/// <summary>
/// 
/// </summary>
public class EsquivoCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Prepara el esquivo.
    /// </summary>
    [Command("esquivar")]
    [Summary("Prepara el esquivo para el siguiente ataque")]
    public async Task ExecuteAsync()

    {
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.EsquivarPokemon(playerName);
        await ReplyAsync(result);
    }

}
using Discord.Commands;

namespace Proyecto_Pokemon;
/// <summary>
/// comando para rendirse en la partida en curso.
/// </summary>
public class RendirseCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// termina la partida en curso dandole la victoria al que no eligió la opcion de rendirse.
    /// </summary>
    [Command("rendirse")]
    [Summary("Termina la partida en curso dandole la victoria al que no eligió la opcion de rendirse")]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.Rendirse(displayName);
        await ReplyAsync(result);
    }
}
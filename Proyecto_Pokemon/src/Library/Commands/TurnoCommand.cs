using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Proyecto_Pokemon;

/// <summary>
/// comando que devuelve de quien es el turno.
/// </summary>
public class TurnoCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Devuelve de quien es el turno.
    /// </summary>
    [Command("turno")]
    [Summary("Te notifica si es tu turno de jugar")]
    public async Task ExecuteAsync()
    {
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.RevisarTurno(playerName);
        await ReplyAsync(result);
    }

}
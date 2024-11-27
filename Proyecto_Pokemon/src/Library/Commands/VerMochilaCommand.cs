using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Proyecto_Pokemon;

/// <summary>
/// Esta clase implementa el comando 'verMochila' del bot.
/// </summary>
public class VerMochilaCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra los items disponibles del jugador.
    /// </summary>
    [Command("verMochila")]
    [Summary("Enseña los objetos de la mochila del jugador")]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.VerMochila(displayName);
        await ReplyAsync(result);
    }
}
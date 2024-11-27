using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Proyecto_Pokemon;

/// <summary>
/// comando para ver los objetos de la mochila
/// </summary>
public class VerMochilaCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra los items disponibles del entrenador
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
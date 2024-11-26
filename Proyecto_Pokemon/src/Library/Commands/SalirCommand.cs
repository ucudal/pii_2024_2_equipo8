using Discord.Commands;

namespace Proyecto_Pokemon;

/// <summary>
/// Esta clase implementa el comando 'salir' del bot.
/// </summary>
public class SalirCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Comando para salir del lobby.
    /// </summary>
    [Command("salir")]
    [Summary("Saca al usuario del Lobby")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string nombre = CommandHelper.GetDisplayName(Context);
        await ReplyAsync(Fachada.SacarEntrenadorDelLobby(nombre));
    }
}

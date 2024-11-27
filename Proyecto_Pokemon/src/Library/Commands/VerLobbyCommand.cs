using Discord.Commands;

namespace Proyecto_Pokemon;

/// <summary>
/// 
/// </summary>
public class VerLobbyCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Comando para recibir los entrenadores en el lobby.
    /// </summary>
    [Command("lobby")]
    [Summary("Muestra quienes estan en el lobby")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        await ReplyAsync(Fachada.VerLobby());
    }
}
using Discord.Commands;

namespace Proyecto_Pokemon;

/// <summary>
/// Comando para saber qué entrenadores hay en el lobby
/// </summary>
public class VerLobbyCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// muestra quienes estan en el lobby esperando por una batalla
    /// </summary>
    [Command("lobby")]
    [Summary("Muestra quienes estan en el lobby")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        await ReplyAsync(Fachada.VerLobby());
    }
}
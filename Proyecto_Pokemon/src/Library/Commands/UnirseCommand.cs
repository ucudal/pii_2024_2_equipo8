using Discord.Commands;


namespace Proyecto_Pokemon;

/// <summary>
/// 
/// </summary>
public class UnirseCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Comando para unirse al lobby.
    /// </summary>
    [Command("unirse")]
    [Summary("Ingresa al usuario al Lobby")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string nombre = CommandHelper.GetDisplayName(Context);
        await ReplyAsync(Fachada.MeterUsuarioAlLobby(nombre));
    }
}
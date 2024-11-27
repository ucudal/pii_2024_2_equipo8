using Discord.Commands;


namespace Proyecto_Pokemon;

/// <summary>
/// Comando para que un usuario se una al lobby.
/// </summary>
public class UnirseCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Permite al usuario unirse al lobby.
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
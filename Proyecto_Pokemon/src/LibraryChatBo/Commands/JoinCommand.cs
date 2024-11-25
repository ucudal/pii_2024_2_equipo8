using Discord.Commands;


namespace Proyecto_Pokemon;

/// <summary>
/// Esta clase implementa el comando 'join' del bot. Este comando une al jugador
/// que envía el mensaje a la lista de jugadores esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class JoinCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'join'. Este comando une al jugador que envía el
    /// mensaje a la lista de jugadores esperando para jugar.
    /// </summary>
    [Command("join")]
    [Summary("Une el usuario que envía el mensaje a la lista de espera")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.Instance.UnirseALaListaDeEspera(Fachada.Instance.SetEntrenadorPorNombre(displayName));
        await ReplyAsync(result);
    }
}

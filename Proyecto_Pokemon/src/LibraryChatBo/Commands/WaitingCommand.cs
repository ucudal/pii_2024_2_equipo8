using Discord.Commands;


namespace Proyecto_Pokemon;

/// <summary>
/// Esta clase implementa el comando 'waitinglist' del bot. Este comando muestra
/// la lista de jugadores esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class WaitingCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'waitinglist'. Este comando muestra la lista de
    /// jugadores esperando para jugar.
    /// </summary>
    [Command("waitinglist")]
    [Summary("Muestra los usuarios en la lista de espera")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string result = Fachada.Instance.VerListaDeEspera();

        await ReplyAsync(result);
    }
}

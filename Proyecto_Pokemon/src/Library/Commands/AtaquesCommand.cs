using Discord;
using Discord.Commands;
using Proyecto_Pokemon;


namespace Library.Commands;

/// <summary>
/// Esta clase se encarga de usar las habilidade disponibles del pokemon para usarlos en el rival.
/// </summary>
public class AtaquesCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra los ataques disponibles del Pokemon activo del jugador.
    /// </summary>
    [Command("ataques")]
    [Summary("")]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.VerHabilidades(displayName);
        await ReplyAsync(result); 
    }
}
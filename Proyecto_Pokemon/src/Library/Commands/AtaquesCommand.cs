using Discord;
using Discord.Commands;
using Proyecto_Pokemon;


namespace Library.Commands;

/// <summary>
/// Esta clase se encarga de usar las habilidades disponibles del pokemon para usarlos en el entrenador rival.
/// </summary>
public class AtaquesCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra los ataques disponibles del Pokemon activo del jugador.
    /// </summary>
    [Command("ataques")]
    [Summary("Muestra todas las habilidades disponibles del pokemon que está a la cabeza")]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.VerHabilidades(displayName);
        await ReplyAsync(result); 
    }
}
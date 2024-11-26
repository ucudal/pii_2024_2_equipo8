using Discord.Commands;
namespace Proyecto_Pokemon;

/// <summary>
/// Esta clase implementa el comando 'elegirRandom' del bot.
/// </summary>
public class ElegirRandomCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Genera equipo random y se asocia al entrenador.
    /// </summary>
    [Command("elegirRandom")]
    [Summary(
        """
        Agrega al equipo del jugador el Pokemon seleccionado.
        Si no se logra agregar envía un mensaje avisando al usuario.
        """)]
    public async Task ExecuteAsync() 
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.elegirRandomente(displayName);
        await ReplyAsync(result);
    }
}
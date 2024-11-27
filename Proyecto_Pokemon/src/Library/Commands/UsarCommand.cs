using Discord.Commands;
namespace Proyecto_Pokemon;

/// <summary>
/// Comando para usar una habilidad de ataque.
/// </summary>
public class UsarCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Comando para elegir y ejecutar una habilidad de ataque.
    /// </summary>
    [Command("usar")]
    [Summary("Usa el ataque o habilidad especificada por el jugador.")]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Ataque que vas a usar.")]
        string? ataque = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.ElegirHabilidad(displayName, ataque);
        await ReplyAsync(result);
    }
}
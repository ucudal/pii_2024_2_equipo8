using Discord.Commands;
namespace Proyecto_Pokemon;

/// <summary>
/// 
/// </summary>
public class UsarCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Comando para usar habilidad como atacar.
    /// </summary>
    [Command("usar")]
    [Summary("")]
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
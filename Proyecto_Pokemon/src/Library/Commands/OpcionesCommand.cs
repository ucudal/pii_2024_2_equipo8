using Discord.Commands;


namespace Proyecto_Pokemon;
/// <summary>
/// Esta clase implementa el comando 'opciones' del bot.
/// </summary>
public class OpcionesCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Comando para mostrar pokemones disponibles.
    /// </summary>
    [Command("opciones")]
    [Summary("Muestra todos los pokemones que se pueden seleccionar para el equipo")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        await ReplyAsync(Fachada.OpcionesPokemones());
    }
}
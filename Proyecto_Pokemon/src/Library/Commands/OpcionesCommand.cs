using Discord.Commands;


namespace Proyecto_Pokemon;
/// <summary>
/// comando para mostrar los pokemones disponibles para selección.
/// </summary>
public class OpcionesCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// muestra todos los pokemones que se pueden seleccionar para el equipo.
    /// </summary>
    [Command("opciones")]
    [Summary("Muestra todos los pokemones que se pueden seleccionar para el equipo")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        await ReplyAsync(Fachada.OpcionesPokemones());
    }
}
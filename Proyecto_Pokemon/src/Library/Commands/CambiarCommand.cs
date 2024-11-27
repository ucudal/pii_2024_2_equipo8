using Discord.Commands;

namespace Proyecto_Pokemon;

/// <summary>
/// comando para cambiar de pokemon durante la batalla.
/// </summary>
public class CambiarCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Permite el cambio entre pokemones del mismo equipo
    /// </summary>
    [Command("cambiar")]
    [Summary("cambia el pokemon que está a la cabeza por otro del equipo")]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("")]
        string pokemonName)
    {
        if (pokemonName == null)
        {await ReplyAsync("Para cambiar de Pokemon tenes que escribir: \n**!cambiar** <**NOMBRE DEL POKEMON MAYUSCULA**>");}
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.CambiarPokemones(playerName, pokemonName);
        await ReplyAsync(result);
    }

}
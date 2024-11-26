using Discord.Commands;

namespace Proyecto_Pokemon;

public class CambiarCommand : ModuleBase<SocketCommandContext>
{
    [Command("cambiar")]
    [Summary("")]
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
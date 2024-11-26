using Discord.Commands;

namespace Proyecto_Pokemon;

public class EsquivoCommand : ModuleBase<SocketCommandContext>
{
    [Command("esquivar")]
    [Summary("")]
    public async Task ExecuteAsync()

    {
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.EsquivarPokemon(playerName);
        await ReplyAsync(result);
    }

}
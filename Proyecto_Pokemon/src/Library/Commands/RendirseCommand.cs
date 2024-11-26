using Discord.Commands;

namespace Proyecto_Pokemon;

public class RendirseCommand : ModuleBase<SocketCommandContext>
{
    [Command("rendirse")]
    [Summary(
        """
        Termina la partida en curso dandole la vicotria al oponente.
        Este comando solo puede ser utilizado por un jugador que esté en una partida..
        """)]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.Rendirse(displayName);
        await ReplyAsync(result);
    }
}
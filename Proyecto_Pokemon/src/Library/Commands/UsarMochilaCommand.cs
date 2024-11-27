using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Proyecto_Pokemon;

/// <summary>
/// comando para usar un item de la mochila
/// </summary>
public class UsarMochilaCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// envia a la fachada un mensaje con el item de cura a usar y el pokemon que se va a potenciar
    /// </summary>
    [Command("curar")]
    [Summary("usa el objeto seleccionado para beneficiar al pokemon especificado.")]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Nombre del item a usar y del Pokemon a ser beneficiado concatenados")]
        string itemAndnombreEntrenador
    )
    {
        string nombreEntrenador;
        string final;
        string objeto;
        string[] objetoconpokemon = itemAndnombreEntrenador.Split(" ");
        if (objetoconpokemon.Length > 2)
        {
            objeto = String.Join(" ", objetoconpokemon, 0, objetoconpokemon.Length-1);
            nombreEntrenador = objetoconpokemon[objetoconpokemon.Length-1];
        }
        else if (objetoconpokemon.Length == 2)
        {
            objeto = objetoconpokemon[0];          
            nombreEntrenador = objetoconpokemon[1];
        }
        else
        {
            final = "Para usar un item debes usar el siguiente formato:\n**!use** <**objeto**> <**pokemon**>";
            await ReplyAsync(final);
            return;
        }

        string displayName = CommandHelper.GetDisplayName(Context);
        final = Fachada.UsarObjetoMochila(displayName, objeto, nombreEntrenador);
        await ReplyAsync(final);
    }
}
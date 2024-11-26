using Discord.Commands;
using Discord;

namespace ProyectoPokemon;

public class TiposCommand : ModuleBase<SocketCommandContext>
{
    [Command("tipos")]
    [Summary("Ver los diferentes tipos de pokemones junto a sus efectividades y debilidades")]
    public async Task ExecuteAsync()
    {
        var embed = new EmbedBuilder()
            .WithTitle("Tabla de tipos")
            .WithColor(Color.Blue)
            .WithImageUrl("https://scontent.fmvd1-1.fna.fbcdn.net/v/t1.6435-9/105942924_153575269595867_8451933193877951128_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=833d8c&_nc_ohc=1suP-pYaILYQ7kNvgFqughY&_nc_zt=23&_nc_ht=scontent.fmvd1-1.fna&_nc_gid=AcAhUkWiqV2jVv_YBy1j9Ot&oh=00_AYBy8p-3Sj3R6CerwSaef6GnF7VhTQUGsHwdAlgaJYST5A&oe=676BE77C")
            .Build();

        await Context.Channel.SendMessageAsync(embed: embed);

    }
}
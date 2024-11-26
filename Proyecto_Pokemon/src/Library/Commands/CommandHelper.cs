using Discord.Commands;
using Discord.WebSocket;

namespace Proyecto_Pokemon;

/// <summary>
/// Clase que proporciona métodos auxiliares para los comandos del bot.
/// </summary>
public static class CommandHelper
{
    /// <summary>
    /// Obtiene el nombre visible de un usuario en el contexto del comando.
    /// </summary>
    public static string GetDisplayName(
        SocketCommandContext context, 
        string? name = null)
    {
        if (name == null)
        {
            name = context.Message.Author.Username;
        }
        
        foreach (SocketGuildUser user in context.Guild.Users)
        {
            if (user.Username == name
                || user.DisplayName == name
                || user.Nickname == name
                || user.GlobalName == name)
            {
                return user.DisplayName;
            }
        }

        return name;
    }

    /// <summary>
    /// Obtiene un usuario del servidor basado en su nombre.
    /// </summary>
    public static SocketGuildUser? GetUser(
        SocketCommandContext context,
        string? name)
    {
        if (name == null)
        {
            return null;
        }
        
        foreach (SocketGuildUser user in context.Guild.Users)
        {
            if (user.Username == name
                || user.DisplayName == name
                || user.Nickname == name
                || user.GlobalName == name)
            {
                return user;
            }
        }

        return null;
    }
}

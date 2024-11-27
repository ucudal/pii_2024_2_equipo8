using Discord.Commands;
using Library.Commands;

namespace Proyecto_Pokemon;

/// <summary>
/// 
/// </summary>
public class HelpComandos : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Comando para soporte con lista de ayuda.
    /// </summary>
    [Command("Help")]
    [Summary("Muestra la lista de comandos disponibles.")]
    public async Task ExecuteAsync()
    {
        string comandos =
        """
            **Lista de comandos disponibles:**
            
            - **!unirse**:  Ingresa al usuario al Lobby.
            - **!lobby**:  Muestra quienes estan en el lobby.
            - **!salir**:  Saca al usuario del Lobby.
            - **!iniciar**:  Empieza la batalla entre dos jugadores que estan en el Lobby.
            - **!tipos**:  Muestra la tabla de tipos con las efectividades.
            - **!elegir**:  Elegir Pokemon.
            - **!elegirRandom**:  Agrega al equipo del jugador Pokemones aleatorios.
            - **!verVida**:  Muestra la vida actual de los Pokémon en batalla.
            - **!ataques**:  Ataques disponibles del Pokemon activo del jugador.
            - **!usar + ataque**:  Ataque que vas a usar.
            - **!cambiar**:  Cambiar Pokemon activo en batalla.
            - **!esquivar**:  Intenta esquivar el ataque del oponente.
            - **!turno**:  Devuelve de quien es el turno.
            - **!curar**:  Usa el item seleccionado para beneficiar al Pokemon especificado.
            - **!verMochila**:  Muestra los items disponibles del jugador.
            - **!rendirse**:  Rendirse y perder
        """;

        await ReplyAsync(comandos);
    }
}


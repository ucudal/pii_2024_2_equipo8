namespace Proyecto_Pokemon;

/// <summary>
/// Clase que gestiona batallas en curso, se divide responsabilidad con batallas para que sea una unica responsabilidad
/// </summary>
public class BatallasEnCurso
{
    /// <summary>
    /// Se crea una lista de las partidas
    /// </summary>
    private List<Batallas> Partidas = new List<Batallas>();
    private Lobby lobby = new Lobby();
    
    /// <summary>
    /// Terminar batalla, bool de indicador si se logra
    /// </summary>
    public bool TerminarPartida(Batallas partida)
    {
        if (Partidas.Remove(partida))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Devolver batalla que contiene entrenador
    /// </summary>
    public Batallas BatallaPorEntrenador(Entrenadores entrenador)
    {
        foreach (Batallas batalla in Partidas)
        {
            if (batalla.JugadoresDisponibles().Contains(entrenador))
            {
                return batalla;
            }
        }
        return null;
    }
    
    /// <summary>
    /// Devolver entrenador presente en batalla según el nombre string
    /// </summary>
    public Entrenadores? EntrenadorPorNombre(string nombre)
    {
        foreach (Batallas partida in Partidas)
        foreach (Entrenadores entrenador in partida.JugadoresDisponibles())
            if (entrenador.Nombre == nombre)
                return entrenador;
        return null;
    }

    /// <summary>
    /// Se agrega nueva batalla a batallasencurso, se retorna la misma
    /// </summary>
    public Batallas CrearPartida(Entrenadores entrenador1, Entrenadores entrenador2)
    {
        Batallas partida = new Batallas(entrenador1, entrenador2);
        partida.Iniciar(entrenador1, entrenador2);
        Partidas.Add(partida);
        return partida;
    }

}
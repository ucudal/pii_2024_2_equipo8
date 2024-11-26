namespace Proyecto_Pokemon;

// Clase que gestiona batallas en curso, se divide responsabilidad con batallas para que sea una unica responsabilidad
public class BatallasEnCurso
{
    private List<Batallas> Partidas = new List<Batallas>();
    private Lobby lobby = new Lobby();
    
    // Terminar batalla, bool de indicador si se logra
    public bool TerminarPartida(Batallas partida)
    {
        if (Partidas.Remove(partida))
        {
            return true;
        }
        return false;
    }

    // Devolver batalla que contiene entrenador 
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
    
    // Devolver entrenador presente en batalla según el nombre string
    public Entrenadores? EntrenadorPorNombre(string nombre)
    {
        foreach (Batallas partida in Partidas)
        foreach (Entrenadores entrenador in partida.JugadoresDisponibles())
            if (entrenador.Nombre == nombre)
                return entrenador;
        return null;
    }

    // Se agrega nueva batalla a batallasencurso, se retorna la misma
    public Batallas CrearPartida(Entrenadores entrenador1, Entrenadores entrenador2)
    {
        Batallas partida = new Batallas(entrenador1, entrenador2);
        partida.Iniciar(entrenador1, entrenador2);
        Partidas.Add(partida);
        return partida;
    }

}